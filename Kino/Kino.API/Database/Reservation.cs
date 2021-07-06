using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public PromoMaterial PromoMaterial { get; set; }
        public int? PromoMaterialId { get; set; }
        public Auditorium Auditorium { get; set; }
        public int AuditoriumId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }
        public virtual ICollection<SeatReservation> SeatReservation { get; set; }
    }
}
