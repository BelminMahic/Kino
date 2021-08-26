using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobileApp.Models
{
    class User
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
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool? Status { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
