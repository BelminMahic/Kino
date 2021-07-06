using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Country
    {
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
