using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Screening
    {
        public int ScreeningId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }
        public DateTime ScreeningStart { get; set; }
    }
}
