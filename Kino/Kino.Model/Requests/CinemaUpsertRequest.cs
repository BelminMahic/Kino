using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class CinemaUpsertRequest
    {
        public string CinemaName { get; set; }

        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public int? CityId { get; set; }
    }
}
