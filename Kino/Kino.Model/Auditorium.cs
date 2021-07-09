using System;

namespace Kino.Model
{
    public class Auditorium
    {
        public int AuditoriumId { get; set; }

        public string AuditoriumName { get; set; }
        public int SeatNumbers { get; set; }
        public int CinemaId { get; set; }

        public override string ToString()
        {
            return AuditoriumName;
        }
    }
}
