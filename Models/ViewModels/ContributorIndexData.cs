using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raindish.Models.ViewModels
{
    public class ContributorIndexData
    {
        public IEnumerable<Contributor> Contributors { get; set; }
        public IEnumerable<SongContributor> SongContributors { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}