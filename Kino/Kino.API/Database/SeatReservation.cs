using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class SeatReservation
    {
        public int SeatReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }
        public MovieSeat MovieSeat { get; set; }
        public int MovieSeatId { get; set; }
    }
}
