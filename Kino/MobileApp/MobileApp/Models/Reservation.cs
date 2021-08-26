using Kino.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int? PromoMaterialId { get; set; }
        public int AuditoriumId { get; set; }

        public Auditorium Auditorium { get; set; }
        public int UserId { get; set; }
        public int ScreeningId { get; set; }

        public Screening Screening { get; set; }

        public Cinema Cinema { get; set; }
    }
}
