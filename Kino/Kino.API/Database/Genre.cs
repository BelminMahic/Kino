using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Genre
    {
        public int GenreId { get; set; }
        [MaxLength(20)]
        [Required]
        public string GenreName { get; set; }
    }
}
