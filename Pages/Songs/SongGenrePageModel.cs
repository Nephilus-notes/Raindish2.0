using Raindish.Data;
using Raindish.Models;
using Raindish.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Raindish.Pages.Songs
{
    public class SongGenresPageModel : PageModel
    {
        public List<AssignedGenreData> AssignedGenreDataList;

        public void PopulateAssignedGenresData(SongContext context,
                                                Song song)
        {
            var allGenres = context.Genres;
            var songGenres = new HashSet<int>(
                song.Genres.Select(g => g.ID));
            AssignedGenreDataList = new List<AssignedGenreData>();
            foreach (var genre in allGenres)
            {
                AssignedGenreDataList.Add(new AssignedGenreData
                {
                    ID = genre.ID,
                    Name = genre.Name,
                    Assigned = songGenres.Contains(genre.ID)
                });
            }
        }
    }
}