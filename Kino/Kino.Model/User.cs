using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string UserName { get; set; }
        public bool? Status { get; set; }
        public int GenderId { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
    }
}
