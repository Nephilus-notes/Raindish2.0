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
    public class DeleteModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public DeleteModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contributors == null)
            {
                return NotFound();
            }
            var contributor = await _context.Contributors.FindAsync(id);

            if (contributor != null)
            {
                Contributor = contributor;
                _context.Contributors.Remove(Contributor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
