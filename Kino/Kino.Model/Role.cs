using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
