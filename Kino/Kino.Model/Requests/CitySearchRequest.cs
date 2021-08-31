using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class CitySearchRequest
    {
        public string CityName { get; set; }
        public int? CountryId { get; set; }
        public string[] IncludeList { get; set; }
    }
}
