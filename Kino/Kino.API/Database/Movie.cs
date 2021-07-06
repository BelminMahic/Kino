using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class Movie
    {
        public int MovieId { get; set; }
        [MaxLength(50)]
        [Required]
        public string MovieName { get; set; }
        [MaxLength(50)]
        [Required]
        public string OriginalMovieName { get; set; }
        [MaxLength(15)]
        [Required]
        public string MovieDuration { get; set; }
        [Required]
        public DateTime ShowTime { get; set; }
        [Required]
        [MaxLength(40)]
        public string DirectorFullName { get; set; }
        [Required]
        public string ActorsName { get; set; }
        public string Description { get; set; }
        public byte[] MoviePoster { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
    }
}
