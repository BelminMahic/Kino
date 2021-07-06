using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Auditorium
    {
        public int AuditoriumId { get; set; }
        [Required]
        [MaxLength(15)]
        public string AuditoriumName { get; set; }
        public int SeatNumbers { get; set; }
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
    }
}
