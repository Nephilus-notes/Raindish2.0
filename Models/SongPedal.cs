namespace Raindish.Models
{
    public class SongPedal
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public int PedalID { get; set; }
        public string? AlternativeTabURL { get; set; }
        public string? AlternativeAudioURL { get; set; }

        public Song Song { get; set; }
        public Pedal Pedal { get; set; }
    }
}
