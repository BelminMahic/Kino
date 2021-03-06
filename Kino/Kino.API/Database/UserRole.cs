using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.API.Database
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public DateTime Changed { get; set; }
    }
}
