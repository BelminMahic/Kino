using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public override string ToString()
        {
            return CountryName;
        }
    }
}
