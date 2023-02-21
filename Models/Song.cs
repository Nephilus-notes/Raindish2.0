using System.ComponentModel.DataAnnotations;

namespace Raindish.Models
{
    public class Song
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? OldNames { get; set; }
        public string? KeySignature { get; set; }
        [Display(Name = "Prod Rec"), Required]
        public Boolean ProductionRecording { get; set; }
        public Boolean Finished { get; set; }
        [DataType(DataType.Date)]
        public DateTime? WrittenOn { get; set; }
        public string? TabsLyricsURL { get; set; }
        public string? AudioFileURL { get; set; }
        public int? UserId { get; set; }
        [Display(Name = "Artists"), Required]

        public ICollection<SongContributor> SongContributors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        [Display(Name = "Pedals")]
        public ICollection<SongPedal>? SongPedals { get; set; }
        public User User { get; set; }
    }
}
