using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Raindish.Data;
using Raindish.Models;

namespace Raindish.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly SongContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(SongContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string TitleSort { get; set; }
        public string KeySignatureSort { get; set; }
        public string DateSort { get; set; }
        // Genre sort (genre must be included)
        // Contributor sort (Contributors must be included as well
        // public Boolean FinishedSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Song> Songs { get; set; }

        public async Task OnGetAsync( string sortOrder, string searchString,
            string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            KeySignatureSort = sortOrder == "Key" ? "key_desc" : "Key";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Song> songsIQ = from s in _context.Songs
                                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                songsIQ = songsIQ.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())
                        || s.OldNames.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    songsIQ = songsIQ.OrderByDescending(s => s.Title);
                    break;
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

            var pageSize = Configuration.GetValue("PageSize", 4);
            Songs = await PaginatedList<Song>.CreateAsync(
                songsIQ.AsNoTracking().Include(s => s.User).Include(s => s.SongGenres),
                pageIndex ?? 1, pageSize);

        }
    }
}
