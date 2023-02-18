namespace Raindish.Models
{
    public class SongContributor
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int ContributorID { get; set; }

        public Song Song { get; set; }
        public Contributor Contributor { get; set; }
    }
}
