﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Model.Requests
{
    public class UserSearchRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool AreRolesLoadingEnabled { get; set; }
    }
}
