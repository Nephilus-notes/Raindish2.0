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

namespace Raindish.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly Raindish.Data.SongContext _context;

        public IndexModel(Raindish.Data.SongContext context)
        {
            _context = context;
        }

        public GenreIndexData GenreData { get;set; } = default!;
        public int GenreID { get; set; }
        public int SongID { get; set; }

        public async Task OnGetAsync(int? id, int? songID)
        {
            GenreData = new GenreIndexData();
            GenreData.Genres = await _context.Genres
                .Include(g => g.Songs)
                    .ThenInclude(s => s.SongContributors)
                .OrderBy(g => g.Name)
                .ToListAsync();

            if (id != null)
            {
                GenreID = id.Value;
                Genre genre = GenreData.Genres
                    .Where(g => g.ID == id.Value).Single();
                GenreData.Songs = genre.Songs;
            }

            if (songID != null)
            {
                SongID = songID.Value;
                IEnumerable<SongContributor> SongContributors = await _context.SongContributors
                    .Where(x => x.SongID == SongID)
                    .Include(c => c.Contributor)
                    .ToListAsync();
                GenreData.SongsContributors = SongContributors;
            }

        }
    }
}
