using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class PromoMaterial
    {
        public int PromoMaterialId { get; set; }
        public string PromoMaterialName { get; set; }
        public int Quantity { get; set; }


        public override string ToString()
        {
            return PromoMaterialName;
        }
    }
}
