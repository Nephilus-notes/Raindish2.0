using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raindish.Models.ViewModels;
using Raindish.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Raindish.Models;

namespace Raindish.Pages
{
    public class AboutModel : PageModel
    {

        private readonly SongContext _context;
        
        public AboutModel(SongContext context)
        {
            _context = context;
        }

        public IList<FinishedGroup> Songs { get; set; }

        public async Task OnGetAsync()
        {
            //System.Diagnostics.Debug.WriteLine("Starting async get");
            IQueryable<FinishedGroup> data =
                from song in _context.Songs
                group song by song.Finished into boolGroup
                select new FinishedGroup()
                {
                    Finished = boolGroup.Key,
                    SongCount = boolGroup.Count()
                };

            System.Diagnostics.Debug.WriteLine(data);
            Songs = await data.AsNoTracking().ToListAsync();
        }
    }
}
