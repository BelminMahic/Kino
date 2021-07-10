using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public override string ToString()
        {
            return GenderName;
        }
    }
}
