using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class MovieSeatUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string MovieSeatRow { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int RowNumber { get; set; }
        public int AuditoriumId { get; set; }
    }
}
