using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raindish.Data;
using Raindish.Models;

namespace Raindish.Pages.Songs
{
    public class DetailsModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public DetailsModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

      public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Genres)
                .Include(s => s.SongPedals)
                .ThenInclude(p => p.Pedal)
                .Include(s => s.SongContributors)
                .ThenInclude(c => c.Contributor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (song == null)
            {
                return NotFound();
            }
            else 
            {
                Song = song;
            }
            return Page();
        }
    }
}
