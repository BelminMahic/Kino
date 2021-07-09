using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string DirectorFullName { get; set; }
        public string ActorsName { get; set; }

        public string OriginalMovieName { get; set; }

        public string MovieDuration { get; set; }

        public DateTime ShowTime { get; set; }
        public string Description { get; set; }
        public byte[] MoviePoster { get; set; }
        public int GenreId { get; set; }
        public int CinemaId { get; set; }

        public override string ToString()
        {
            return MovieName;
        }

    }
}
