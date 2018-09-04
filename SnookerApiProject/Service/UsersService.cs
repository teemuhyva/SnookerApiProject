using SnookerApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Service
{
    public interface IUsersService
    {
        User GetUserWithName(string name);
    }
}