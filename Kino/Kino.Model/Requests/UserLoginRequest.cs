using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
