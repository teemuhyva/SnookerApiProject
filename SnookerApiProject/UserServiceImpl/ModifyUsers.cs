﻿using SnookerApiProject.Models;
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

        public PlayerProfile RegisterNewUser(PlayerProfile user) {
            var profile = (from player in snookerEnt.UserProfile
                             where player.nickName == user.NickName
                             select player).FirstOrDefault();
            if (profile == null) {
                var newUser = new UserProfile {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    nickName = user.NickName,
                    isPublic = 1,
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