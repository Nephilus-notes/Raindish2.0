using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raindish.Data;
using Raindish.Models;

namespace Raindish.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public CreateModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          var emptySong = new Song();

            if (await TryUpdateModelAsync<Song>(
                    emptySong,
                    "song",
                    s => s.Title, s => s.OldNames, s => s.KeySignature, s => s.ProductionRecording, 
                    s => s.Finished, s => s.WrittenOn, s => s.TabsLyricsURL, s => s.AudioFileURL))
            {
                _context.Songs.Add(emptySong);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();

    }
    }
}
