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
    public class CreateModel : SongGenresPageModel
    {
        private readonly SongContext _context;
        private readonly ILogger<SongGenresPageModel> _logger;

        public CreateModel(SongContext context,
                            ILogger<SongGenresPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var song = new Song();
            song.Genres = new List<Genre>();

            // Provides an empty collect for the foreach loop
            // foreach (var genre in Model.AssignedGenreDataList)
            // in the Create Razor page.
            PopulateAssignedGenresData(_context, song);
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
          var newSong = new Song();

            if (selectedGenres.Length == 0)
            {
                newSong.Genres = new List<Genre>();
                // Load collection with one DB call
                _context.Genres.Load();
            }

            foreach (var genre in selectedGenres)
            {
                var foundGenre = await _context.Genres.FindAsync(int.Parse(genre));
                if (foundGenre != null)
                {
                    System.Diagnostics.Debug.WriteLine(foundGenre);
                    System.Diagnostics.Debug.WriteLine(foundGenre.Name);
                    System.Diagnostics.Debug.WriteLine(foundGenre.Songs);

                    newSong.Genres.Add(foundGenre);
                }
                else
                {
                    _logger.LogWarning("Genre {genre} not found", genre);
                }
            }
            try 
            { 
                if (newSong != null) 
                {
                    var updateResult = await TryUpdateModelAsync<Song>(
                     newSong,
                    "song",
                    s => s.Title, s => s.OldNames, s => s.KeySignature, s => s.ProductionRecording,
                    s => s.Finished, s => s.WrittenOn, s => s.TabsLyricsURL, s => s.AudioFileURL);

                    _context.Songs.Add(newSong);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            PopulateAssignedGenresData(_context, newSong);
            return Page();
        }
    }
}
