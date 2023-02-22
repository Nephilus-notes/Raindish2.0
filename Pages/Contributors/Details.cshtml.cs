using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raindish.Data;
using Raindish.Models;

namespace Raindish._01.Pages.Contributors
{
    public class DetailsModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public DetailsModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

      public Contributor Contributor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contributors == null)
            {
                return NotFound();
            }

            var contributor = await _context.Contributors.FirstOrDefaultAsync(m => m.ID == id);
            if (contributor == null)
            {
                return NotFound();
            }
            else 
            {
                Contributor = contributor;
            }
            return Page();
        }
    }
}
