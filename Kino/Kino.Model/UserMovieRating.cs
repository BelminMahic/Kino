using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class UserMovieRating
    {
        public int UserMovieRatingId { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int Rating { get; set; }
    }
}
