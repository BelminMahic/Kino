using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class PromoMaterialUpsertRequest
    {
        public string PromoMaterialName { get; set; }
        public int Quantity { get; set; }
    }
}
