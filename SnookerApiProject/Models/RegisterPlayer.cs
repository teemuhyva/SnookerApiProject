﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Models
{
    public class RegisterPlayer
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
    }
}