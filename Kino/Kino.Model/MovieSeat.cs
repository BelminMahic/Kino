using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class MovieSeat
    {
        public int MovieSeatId { get; set; }

        public string MovieSeatRow { get; set; }
        public int RowNumber { get; set; }
        public int AuditoriumId { get; set; }

        public override string ToString()
        {
            return $"{MovieSeatRow}+{RowNumber}";
        }
    }
}
