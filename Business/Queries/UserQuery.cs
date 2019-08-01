﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Queries
{
    public class UserQuery : BaseQuery
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
