using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model.Requests
{
    public class PromoMaterialUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]

        public string PromoMaterialName { get; set; }
        [Required(AllowEmptyStrings = false)]

        public int Quantity { get; set; }
    }
}
