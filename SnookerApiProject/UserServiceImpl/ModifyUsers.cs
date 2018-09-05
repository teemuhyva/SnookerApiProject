using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SnookerApiProject.UserServiceImpl
{
    public class ModifyUsers : IUsersService {
        readonly SnookerAppEntitie3 snookerEnt = new SnookerAppEntitie3();
        
        public User RegisterNewUser(User user) {
            if(user != null) {
                var newUser = new Players {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    nickName = user.NickName
                };

                snookerEnt.Players.Add(newUser);
                snookerEnt.SaveChanges();
            }

            return user;
        }

        public string RemovePlayer(User user) {

            var checkItem = snookerEnt.Players.SingleOrDefault(p => p.nickName == user.NickName);
            if(checkItem != null) {
                snookerEnt.Players.Remove(checkItem);
                snookerEnt.SaveChanges();
            }

            return "removed";
        }

        public User UpdateUser(User user) {
            var checkUser = snookerEnt.Players.SingleOrDefault(p => p.nickName == user.NickName);
            
            if(checkUser != null) {
                var updatedPlayer = new Players {
                    nickName = user.NickName
                };

                snookerEnt.Players.Add(checkUser);
                snookerEnt.SaveChanges();
            }

            return user;
        }
    }
}