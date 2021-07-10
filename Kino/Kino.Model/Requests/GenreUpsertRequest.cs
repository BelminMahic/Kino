using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class GenreUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string GenreName { get; set; }

    }
}
