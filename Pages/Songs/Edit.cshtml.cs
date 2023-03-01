using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raindish.Data;
using Raindish.Models;

namespace Raindish.Pages.Songs
{
    public class EditModel : SongGenresPageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public EditModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song =  await _context.Songs
                .Include(s => s.Genres)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Song == null)
            {
                return NotFound();
            }

            PopulateAssignedGenresData(_context, Song);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

           var songToUpdate = await _context.Songs
                .Include(s => s.Genres)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (songToUpdate == null)
            {
                return NotFound();
            }
            //System.Diagnostics.Debug.Write("Hitting the conditional \n");
            //System.Diagnostics.Debug.WriteLine(songToUpdate.Title);
            //System.Diagnostics.Debug.WriteLine(selectedGenres.Length);

            if (songToUpdate != null) 
            {
                var UpdateResult = await TryUpdateModelAsync<Song>(
                songToUpdate,
                "song",
                s => s.Title, s => s.OldNames, s => s.KeySignature, s => s.ProductionRecording,
                    s => s.Finished, s => s.WrittenOn, s => s.TabsLyricsURL, s => s.AudioFileURL);

                UpdateSongGenres(selectedGenres, songToUpdate);

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateSongGenres(selectedGenres, songToUpdate);
            PopulateAssignedGenresData(_context, songToUpdate);
            return Page();
        }

        public void UpdateSongGenres(string[] selectedGenres,
                                        Song songToUpdate)
        {
            if (selectedGenres == null)
            {
                songToUpdate.Genres = new List<Genre>();
                return;
            }

            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var songGenres = new HashSet<int>
                (songToUpdate.Genres.Select(g => g.ID));
            foreach (var genre in _context.Genres)
            {
                if (selectedGenresHS.Contains(genre.ID.ToString()))
                {
                    if (!songGenres.Contains(genre.ID))
                    {
                        songToUpdate.Genres.Add(genre);
                    }
                }
                else
                {
                    if (songGenres.Contains(genre.ID))
                    {
                        var genreToRemove = songToUpdate.Genres.Single(
                                                        g => g.ID == genre.ID);
                        songToUpdate.Genres.Remove(genreToRemove);
                    }
                    //System.Diagnostics.Debug.WriteLine("Selected genre is this long:");
                    //System.Diagnostics.Debug.WriteLine(selectedGenres.Length);
                    foreach (var debugGenre in selectedGenres) {
                    //System.Diagnostics.Debug.WriteLine(debugGenre.GetType());

                    }
                }
            }
        }

        private bool SongExists(int id)
        {
          return _context.Songs.Any(e => e.ID == id);
        }
    }
}
