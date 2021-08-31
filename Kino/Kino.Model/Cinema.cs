using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class Cinema
    {
        public int CinemaId { get; set; }

        public string CinemaName { get; set; }

        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }

        public override string ToString()
        {
            return CinemaName;
        }
    }
}
