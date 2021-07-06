using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class Screening
    {
        public int ScreeningId { get; set; }
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }
        public DateTime ScreeningStart { get; set; }
    }
}
