using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raindish.Data;
using Raindish.Models;

namespace Raindish._01.Pages.Contributors
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
            return Page();
        }

        [BindProperty]
        public Contributor Contributor { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contributors.Add(Contributor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
