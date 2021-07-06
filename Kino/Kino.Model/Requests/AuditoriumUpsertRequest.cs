using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class AuditoriumUpsertRequest
    {
        public string AuditoriumName { get; set; }
        public int SeatNumbers { get; set; }
        public int CinemaId { get; set; }
    }
}
