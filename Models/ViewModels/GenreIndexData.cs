using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raindish.Models.ViewModels
{
    public class GenreIndexData
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public IEnumerable<SongContributor> SongsContributors { get; set;}
    }
}