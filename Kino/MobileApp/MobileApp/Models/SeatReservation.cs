using Kino.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class SeatReservation
    {
        public int SeatReservationId { get; set; }
        public int ReservationId { get; set; }
        public int ScreeningId { get; set; }
        public int MovieSeatId { get; set; }
    }
}
