using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class MovieSeatUpsertRequest
    {
        public string MovieSeatRow { get; set; }
        public int RowNumber { get; set; }
        public int AuditoriumId { get; set; }
    }
}
