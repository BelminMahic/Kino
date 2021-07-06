using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class ScreeningSearchRequest
    {
        public int? MovieId { get; set; }
        public int? AuditoriumId { get; set; }
    }
}
