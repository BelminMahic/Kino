using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class UserUpsertRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public int GenderId { get; set; }
        public List<int> Roles { get; set; } = new List<int>();
    }
}
