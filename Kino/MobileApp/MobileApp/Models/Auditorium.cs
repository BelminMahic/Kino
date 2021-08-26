using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Auditorium
    {
        public int AuditoriumId { get; set; }
        public string AuditoriumName { get; set; }
        public int SeatNumbers { get; set; }
        public int CinemaId { get; set; }
    }
}
