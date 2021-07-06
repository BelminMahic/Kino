using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class SeatReservation
    {
        public int SeatReservationId { get; set; }
        public int ReservationId { get; set; }
        public int ScreeningId { get; set; }
        public int MovieSeatId { get; set; }
    }
}
