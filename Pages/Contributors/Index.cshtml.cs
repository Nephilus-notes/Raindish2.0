using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raindish.Data;
using Raindish.Models;
using Raindish.Models.ViewModels;

namespace Raindish.Pages.Contributors
{
    public class IndexModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public IndexModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

        public ContributorIndexData ContributorData { get;set; } = default!;
        public int ContributorID { get; set; }
        public int SongID { get; set; }

        public async Task OnGetAsync(int? id, int? songID)
        {
            ContributorData = new ContributorIndexData();
            ContributorData.Contributors = await _context.Contributors
                .Include(c => c.SongContributors)
                    .ThenInclude(s => s.Song.Genres)
                    .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                ContributorID = id.Value;
                Contributor contributor = ContributorData.Contributors
                    .Where(g => g.ID == id.Value)
                    .Single();
                System.Diagnostics.Debug.WriteLine("Manual Output");
                System.Diagnostics.Debug.WriteLine(contributor);
                System.Diagnostics.Debug.WriteLine(contributor.ArtistName);
                System.Diagnostics.Debug.WriteLine(contributor.SongContributors);
                foreach (var artist in contributor.SongContributors)
                {
                System.Diagnostics.Debug.WriteLine(artist.Song.Title);
                }

                ContributorData.SongContributors = contributor.SongContributors;
            }

            if (songID != null)
            {
                //SongID = songID.Value;
                //IEnumerable<Genre> Genres = await _context.Genres
                //    .Include(g => g.Songs)
                //    //.Where(x => x.Songs.Contains(Song.ID == SongID)
                //    //.Include(c => c.Contributor)
                //    .ToListAsync();

                //var songGenres = 
                //    from songs in Genres.Songs
                //    where 
                //ContributorData.Genres = Genres;
            }
        }
    }
}
