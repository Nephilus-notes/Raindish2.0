using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raindish.Models;

namespace Raindish.Data
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<SongContributor> SongContributors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<SongPedal> SongPedals { get; set; }
        public DbSet<Pedal> Pedals { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Contributor> Contributors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().ToTable(nameof(Song));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Contributor>().ToTable(nameof(Contributor));
            modelBuilder.Entity<Genre>().ToTable(nameof(Genre));
            modelBuilder.Entity<Pedal>().ToTable(nameof(Pedal));
            modelBuilder.Entity<SongGenre>().ToTable(nameof(SongGenre));
            modelBuilder.Entity<SongPedal>().ToTable(nameof(SongPedal));
            modelBuilder.Entity<SongContributor>().ToTable(nameof(SongContributor));
        }
    }
}
