using Raindish.Models;
using Raindish.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Raindish._01.Models.ViewModels;
using Raindish.Data;

namespace Raindish.Pages.Songs
{
    public class CreateSongPageModel : PageModel
    {
        public List <AssignedGenreData> AssignedGenreDataList;
        public List <AssignedPedalData> AssignedPedalDataList;
        public List <AssignedContributorData> AssignedContributorDataList;

        public void PopulateAssignedItems(SongContext context,
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

            //var allPedals = context.Pedals;
            //var songPedals = new HashSet<int>(
            //    song.SongPedals.Select(sp => sp.PedalID));
            //AssignedPedalDataList = new List<AssignedPedalData>();
            //foreach (var pedal in allPedals)
            //{
            //    AssignedPedalDataList.Add(new AssignedPedalData
            //    {
            //        ID = pedal.ID,
            //        Name = pedal.Name,
            //        Assigned = songPedals.Contains(pedal.ID)
            //    });
            //}

            //var allContributors = context.Contributors;
            //var songContributors = new HashSet<int>(
            //    song.SongContributors.Select(sc => sc.ID));
            //AssignedContributorDataList = new List<AssignedContributorData>();
            //foreach (var contributor in allContributors)
            //{
            //    AssignedContributorDataList.Add(new AssignedContributorData
            //    {
            //        ID = contributor.ID,
            //        ArtistName = contributor.ArtistName,
            //        Assigned = songContributors.Contains(contributor.ID)
            //    });
            // }
        }
    }
}
