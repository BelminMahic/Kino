using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class SeatReservationUpsertRequest
    {
        public int ReservationId { get; set; }
        public int ScreeningId { get; set; }
        public int MovieSeatId { get; set; }
    }
}
