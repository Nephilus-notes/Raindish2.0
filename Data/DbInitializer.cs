using Raindish.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var charles = new User
            {
                Name = "Charles",
                Email = "Cmhmcc@gmail.com",
                Password = "Sup",
                PhoneNumber = "3145205612"
            };

            var shawn = new User
            {
                Name = "Shawn",
                Email = "",
                Password = "Sup",
                PhoneNumber = "3145205612"
            };

            var users = new User[]
            {
                charles,
                shawn
            };

            context.Users.AddRange(users);

            var altMetal = new Genre
            {
                Name = "Alt Metal"
            };
            var alt = new Genre
            {
                Name = "Alt"
            };
            var folk = new Genre
            {
                Name = "Folk"
            };
            var blues = new Genre
            {
                Name = "Blues"
            };
            var closer = new Genre
            {
                Name = "Closer"
            };

            var atmospheric = new Genre
            {
                Name = "Atmospheric"
            };


            var genres = new Genre[]
            {
                altMetal,
                alt,
                folk, 
                blues,
                closer,
                atmospheric,
            };

            context.Genres.AddRange(genres);

            var nephilus = new Contributor
            {
                ArtistName = "Nephilus",
            };

            var po = new Contributor
            {
                ArtistName = "Po Mia"
            };

            var conttributors = new Contributor[]
            {
                nephilus, 
                po
            };

            context.Contributors.AddRange(conttributors);

            var looper = new Pedal
            {
                Name = "Looper",
                Description = "VSN Twin Looper with variable speed, reverse, two channels, and channel switching"
            };

            var distortion = new Pedal
            {
                Name = "Distortion",
            };

            var pedals = new Pedal[]
            {
                looper,
                distortion
            };

            context.Pedals.AddRange(pedals);

            System.Diagnostics.Debug.WriteLine(blues);
            System.Diagnostics.Debug.WriteLine(closer);

            var trouble = new Song
            {
                Title = "Trouble You Can Borrow",
                OldNames = "For Today",
                KeySignature = "A Minor",
                ProductionRecording = true,
                Finished = true,
                WrittenOn = DateTime.Parse("2021-05-21"),
                TabsLyricsURL = "",
                AudioFileURL = "",
                User = charles,
                Genres = new List<Genre> { blues }
            };

            var everything = new Song
            {
                Title = "Everything But Desire",
                OldNames = "",
                KeySignature = "E Power",
                ProductionRecording = true,
                Finished = true,
                WrittenOn = DateTime.Parse("2022-05-21"),
                TabsLyricsURL = "",
                AudioFileURL = "",
                User = charles,
                Genres = new List<Genre> { altMetal }
            };

            var bts = new Song
            {
                Title = "These Words",
                OldNames = "Better Than Sin",
                KeySignature = "A Minor",
                ProductionRecording = true,
                Finished = true,
                WrittenOn = DateTime.Parse("2020-05-21"),
                TabsLyricsURL = "",
                AudioFileURL = "",
                User = shawn,
                Genres = new List<Genre> { folk }
            };

            var sinnerman = new Song
            {
                Title = "Sinnerman",
                OldNames = "",
                KeySignature = "D Minor",
                ProductionRecording = false,
                Finished = true,
                WrittenOn = DateTime.Parse("2021-05-21"),
                TabsLyricsURL = "https://docs.google.com/document/d/1cT3pxNDKaxqP2u72cDRGyUCvYb7jq2u_Ed0yElG0VIs/edit",
                AudioFileURL = "",
                User = charles,
                Genres = new List<Genre> { alt }
            };

            var songs = new Song[]
            {
                trouble,
                everything,
                bts,
                sinnerman
            };


            var songContributors = new SongContributor[]
            {
                new SongContributor{Song=trouble,Contributor=nephilus},
                new SongContributor{Song = everything, Contributor = nephilus},
                new SongContributor{Song=everything, Contributor=po},
                new SongContributor{Song=bts,Contributor=nephilus},
                new SongContributor{Song=sinnerman,Contributor=po},
            };

            context.SongContributors.AddRange(songContributors);


            var songPedals = new SongPedal[]
            {
                new SongPedal{Song=everything, Pedal=looper},
                new SongPedal{Song=everything, Pedal=distortion}
            };

            context.SongPedals.AddRange(songPedals);

            context.Songs.AddRange(songs);
            context.SaveChanges();
        }
    }
}