namespace Raindish.Models
{
    public class Pedal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<SongPedal> SongPedals { get; set; }
    }
}
