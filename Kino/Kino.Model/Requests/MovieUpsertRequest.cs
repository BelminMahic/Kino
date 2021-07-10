using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class MovieUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]

        public string MovieName { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string OriginalMovieName { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string DirectorFullName { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string ActorsName { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string MovieDuration { get; set; }
        [Required(AllowEmptyStrings = false)]

        public DateTime ShowTime { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string Description { get; set; }
        public byte[] MoviePoster { get; set; }
        public int GenreId { get; set; }
        public int CinemaId { get; set; }
    }
}
