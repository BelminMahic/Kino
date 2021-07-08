using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
