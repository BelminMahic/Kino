using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class CinemaSearchRequest
    {
        public string CinemaName { get; set; }
        public int? CityId { get; set; }
        public string[] IncludeList { get; set; }

    }
}
