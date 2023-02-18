using System;
using System.ComponentModel.DataAnnotations;

namespace Raindish.Models.ViewModels
{
    public class FinishedGroup
    {
        public bool Finished { get; set; }

        public int SongCount { get; set; }
    }
}