using Raindish.Models;

namespace Raindish.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SongContext context)
        {
            if (context.Songs.Any())
            {
                return;
            }
            var songs = new Song[]
            {
                new Song{Title="Trouble You Can Borrow",ProductionRecording=true,Finished=true},
                new Song{Title="Everything But Desire",ProductionRecording=true,Finished=true},
                new Song{Title="Better Than Sin",ProductionRecording=true,Finished=true},
                new Song{Title="Sinnerman",ProductionRecording=false,Finished=false}
            };

            context.Songs.AddRange(songs);
            //context.SaveChanges();

            var genres = new Genre[]
            {
                new Genre{Name="Alt Metal"},
                new Genre{Name="Alt"},
                new Genre{Name="Folk"},
                new Genre{Name="Blues"},
                new Genre{Name="Closer"},
                new Genre{Name="Atmospheric"}
            };

            context.Genres.AddRange(genres);
            // context.SaveChanges();

            var pedals = new Pedal[]
            {
                new Pedal{Name="Looper"},
                new Pedal{Name="Distortion"}
            };

            context.Pedals.AddRange(pedals);
            // context.SaveChanges();

            var conttributors = new Contributor[]
            {
                new Contributor{ArtistName="Nephilus" }
            };

            context.Contributors.AddRange(conttributors);
            //context.SaveChanges();

            var songContributors = new SongContributor[]
            {
                new SongContributor{SongID=1,ContributorID=1}
            };

            context.SongContributors.AddRange(songContributors);
            //.SaveChanges();

            var songGenres = new SongGenre[]
            {
                new SongGenre {SongID=1,GenreID=4},
            };

            context.SongGenres.AddRange(songGenres);
            // context.SaveChanges();

            var songPedals = new SongPedal[]
            {
                new SongPedal{SongID=2, PedalID=1}
            };

            context.SongPedals.AddRange(songPedals);

            var users = new User[]
            {
                new User{Name="Charles"}
            };
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}