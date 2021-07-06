using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kino.Model
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]

        public string UserName { get; set; }
        public bool? Status { get; set; }
        public int GenderId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
