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
    public class IndexModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public IndexModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
        public string KeySignatureSort { get; set; }
        public string DateSort { get; set; }
        // Genre sort (genre must be included)
        // Contributor sort (Contributors must be included as well
        // public Boolean FinishedSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Song> Songs { get;set; } = default!;

        public async Task OnGetAsync( string sortOrder)
        {
            // using System;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            KeySignatureSort = sortOrder == "Key" ? "key_desc" : "Key";
            // FinishedSort =

            IQueryable<Song> songsIQ = from s in _context.Songs
                                       select s;

            switch (sortOrder)
            {
                case "title_desc":
                    songsIQ = songsIQ.OrderByDescending(s => s.Title);
                    break;
                //case "Date":
                //    songsIQ = songsIQ.OrderBy(s => s.WrittenOn);
                //    break;
                //case "date_desc":
                //    songsIQ = songsIQ.OrderByDescending(s => s.WrittenOn);
                //    break;
                case "Key":
                    songsIQ = songsIQ.OrderBy(s => s.KeySignature);
                    break;
                case "key_desc":
                    songsIQ = songsIQ.OrderByDescending(s => s.KeySignature);
                    break;
                default:
                    songsIQ = songsIQ.OrderBy(s => s.Title);
                    break;

            }

                Songs = await _context.Songs
                .Include(s => s.User).ToListAsync();

        }
    }
}
