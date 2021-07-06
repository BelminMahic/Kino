using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public DateTime Changed { get; set; }

        public User Users { get; set; }
        public Role Roles { get; set; }
    }
}
