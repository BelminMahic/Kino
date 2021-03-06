using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class UserMovieRating
    {
        public int UserMovieRatingId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public int Rating { get; set; }
    }
}
