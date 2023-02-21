using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raindish.Data;
using Raindish.Models;

namespace Raindish._01.Pages.Genres
{
    public class DeleteModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public DeleteModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.FirstOrDefaultAsync(m => m.ID == id);

            if (genre == null)
            {
                return NotFound();
            }
            else 
            {
                Genre = genre;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }
            var genre = await _context.Genres.FindAsync(id);

            if (genre != null)
            {
                Genre = genre;
                _context.Genres.Remove(Genre);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
