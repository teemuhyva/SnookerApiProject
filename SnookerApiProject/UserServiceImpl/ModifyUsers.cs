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
        SnookerApiProject2_dbEntities snookerEnt = new SnookerApiProject2_dbEntities();

        public RegisterPlayer RegisterPlayer(RegisterPlayer player)
        {
            var playerFound = (from register in snookerEnt.RegisteredPlayers
                               where register.email == player.Email && register.nickName == player.NickName
                               select register).SingleOrDefault();

            if(playerFound == null) 
            {
                var newRegistration = new RegisteredPlayers
                {
                    firstName = player.FirstName,
                    lastName = player.LastName,
                    nickName = player.NickName,
                    email = player.Email,
                    password = player.Password
                };

                snookerEnt.RegisteredPlayers.Add(newRegistration);
                snookerEnt.SaveChanges();
            }

            return player;
        }

        public PlayerProfile AddNewPlayerProfile(PlayerProfile user) {
            var profile = (from player in snookerEnt.UserProfile
                             where player.nickName == user.NickName
                             select player).FirstOrDefault();
            if (profile == null) {
                var newUser = new UserProfile {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    nickName = user.NickName,
                    isPublic = user.IsPublic,
                    isFriendsOnly = 0
                };

                snookerEnt.UserProfile.Add(newUser);
                snookerEnt.SaveChanges();
            }

            return user;
        }

        public string RemovePlayer(PlayerProfile user) {

            var checkItem = snookerEnt.UserProfile.SingleOrDefault(p => p.nickName == user.NickName);
            if(checkItem != null) {
                snookerEnt.UserProfile.Remove(checkItem);
                snookerEnt.SaveChanges();
            }

            return "removed";
        }

        public PlayerProfile UpdateUser(PlayerProfile user) {
            var checkUser = snookerEnt.UserProfile.SingleOrDefault(p => p.nickName == user.NickName);
            
            if(checkUser != null) {
                PlayerProfile profile = new PlayerProfile();
                profile.CheckEmptyFields(user, checkUser);
                var updatedPlayer = new UserProfile {
                    firstName = profile.FirstName,
                    lastName = profile.LastName,                    
                    nickName = user.NickName,
                    isPublic = user.IsPublic,
                    isFriendsOnly = user.IsFriendsOnly
                };

                snookerEnt.UserProfile.Add(checkUser);
                snookerEnt.SaveChanges();
            }

            return user;
        }

        public PlayerProfile FindPlayerByNick(PlayerProfile playerProfile) {

            var found = (from profile in snookerEnt.UserProfile
                         where profile.nickName == playerProfile.NickName
                         select profile).SingleOrDefault();

            if (found != null) {
                if(found.isPublic == 1) {
                    playerProfile = new PlayerProfile {
                        NickName = found.nickName,
                        FirstName = found.firstName,
                        LastName = found.lastName
                    };
                return playerProfile;
                } else {
                    throw new Exception("Player profile not public");
                }
            } else {
                throw new Exception("Player not found");
            }
        }
    }
}