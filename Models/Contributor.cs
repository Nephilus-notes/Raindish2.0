namespace Raindish.Models
{
    public class Contributor
    {
        public int ID { get; set; }
        public string ArtistName { get; set; }

        public ICollection<SongContributor> SongContributors { get; set; }
    }
}
