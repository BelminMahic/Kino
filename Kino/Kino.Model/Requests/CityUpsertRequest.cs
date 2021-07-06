using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class CityUpsertRequest
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
