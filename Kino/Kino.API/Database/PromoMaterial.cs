using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class PromoMaterial
    {
        public int PromoMaterialId { get; set; }
        [Required]
        [MaxLength(30)]

        public string PromoMaterialName { get; set; }
        public int Quantity { get; set; }
    }
}
