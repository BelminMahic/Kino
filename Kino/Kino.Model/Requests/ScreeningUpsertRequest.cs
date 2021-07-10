using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class ScreeningUpsertRequest
    {
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }
        [Required(AllowEmptyStrings = false)]

        public DateTime ScreeningStart { get; set; }
    }
}
