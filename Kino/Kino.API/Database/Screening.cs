using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Screening
    {
        public int ScreeningId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Auditorium Auditorium { get; set; }
        public int AuditoriumId { get; set; }
        public DateTime ScreeningStart { get; set; }
    }
}
