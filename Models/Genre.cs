﻿namespace Raindish.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<SongGenre> SongGenres { get; set; }
    }
}
