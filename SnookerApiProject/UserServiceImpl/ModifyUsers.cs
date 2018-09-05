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

        public User GetUserWithName() {          
            return new User {
                FirstName = "Teemu",
                LastName = "Hyvarinen",
                NickName = "Matty"
            };
        }
        
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
            var found = from p in snookerEnt.Players
                        where p.nickName.Equals(user.NickName)
                        select p;

            if(found != null) {
                snookerEnt.Entry(found).State = EntityState.Deleted;
                snookerEnt.SaveChanges();
            }

            return "removed";
        }
    }
}