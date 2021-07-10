using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class CityUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]

        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
