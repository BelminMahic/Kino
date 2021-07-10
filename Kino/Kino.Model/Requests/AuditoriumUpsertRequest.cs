using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class AuditoriumUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string AuditoriumName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int SeatNumbers { get; set; }
        public int CinemaId { get; set; }
    }
}
