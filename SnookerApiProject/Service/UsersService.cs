using SnookerApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Service
{
    public interface IUsersService {
        PlayerProfile AddNewPlayerProfile(PlayerProfile user);

        PlayerProfile UpdateUser(PlayerProfile user);

        string RemovePlayer(PlayerProfile user);

        PlayerProfile FindPlayerByNick(PlayerProfile playerProfile);

        RegisterPlayer RegisterPlayer(RegisterPlayer player);
    }
}