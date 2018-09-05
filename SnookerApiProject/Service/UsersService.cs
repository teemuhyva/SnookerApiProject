using SnookerApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Service
{
    public interface IUsersService {
        User RegisterNewUser(User user);

        User UpdateUser(User user);

        string RemovePlayer(User user);
    }
}