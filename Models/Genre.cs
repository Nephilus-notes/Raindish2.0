namespace Raindish.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
