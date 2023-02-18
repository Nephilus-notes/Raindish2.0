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
    public class EditModel : PageModel
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

            Song =  await _context.Songs.FindAsync(id);

            if (Song == null)
            {
                return NotFound();
            }
           
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
           var songToUpdate = await _context.Songs.FindAsync(id);

            if (songToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Song>(
                songToUpdate,
                "song",
                s => s.Title, s => s.OldNames, s => s.KeySignature, s => s.ProductionRecording,
                    s => s.Finished, s => s.WrittenOn, s => s.TabsLyricsURL, s => s.AudioFileURL))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private bool SongExists(int id)
        {
          return _context.Songs.Any(e => e.ID == id);
        }
    }
}
