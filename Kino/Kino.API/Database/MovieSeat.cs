using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class MovieSeat
    {
        public int MovieSeatId { get; set; }
        [Required]
        [MaxLength(15)]
        public string MovieSeatRow { get; set; }
        [Required]
        public int RowNumber { get; set; }
        public Auditorium Auditorium { get; set; }
        public int AuditoriumId { get; set; }
        public virtual ICollection<SeatReservation> SeatReservation { get; set; }

    }
}
