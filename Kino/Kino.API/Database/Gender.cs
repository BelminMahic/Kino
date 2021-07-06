using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Gender
    {
        public int GenderId { get; set; }
        [Required]
        [MaxLength(10)]
        public string GenderName { get; set; }
    }
}
