using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class CountryUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string CountryName { get; set; }

    }
}
