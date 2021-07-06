using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class ReservationUpsertRequest
    {
        public DateTime ReservationDate { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int? PromoMaterialId { get; set; }
        public int AuditoriumId { get; set; }
        public int UserId { get; set; }
        public int ScreeningId { get; set; }
    }
}
