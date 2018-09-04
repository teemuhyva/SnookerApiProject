using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.UserServiceImpl
{
    public class ModifyUsers : IUsersService
    {
        public User GetUserWithName(string name)
        {
          
            return new User
            {
                FirstName = "Teemu",
                LastName = "Hyvarinen",
                NickName = "Matty"

            };
        }
        
    }
}