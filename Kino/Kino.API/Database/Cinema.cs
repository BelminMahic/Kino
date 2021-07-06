using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CinemaName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
