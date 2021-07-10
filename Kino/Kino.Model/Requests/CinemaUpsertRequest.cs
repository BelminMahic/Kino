using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class CinemaUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string CinemaName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }
        [Phone]
        [Required(AllowEmptyStrings = false)]
        public string TelephoneNumber { get; set; }
        public int? CityId { get; set; }
    }
}
