using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class MovieSearchRequest
    {
        public string MovieName { get; set; }
        public int? GenreId { get; set; }
        public int? CinemaId { get; set; }

        public string[] IncludeList { get; set; }


    }
}
