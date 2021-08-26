using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class UserMovieRatingSearchRequest
    {
        public int? UserMovieRatingId { get; set; }

        public int? UserId { get; set; }

        public int? MovieId { get; set; }
    }
}
