using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
