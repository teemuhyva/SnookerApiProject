using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.UserServiceImpl {
    public class FriendsServiceImpl : IFriends {

        SnookerAppEntities snookerEnt = new SnookerAppEntities();

        public Friend FindFriendByNick(string nickName) {
            var found = snookerEnt.Friends.SingleOrDefault(p => p.friendNick == nickName);
            if (found != null) {
                var foundFriend = new Friend {
                    FirstName = found.friendFirstName,
                    LastName = found.friendLastName,
                    NickName = found.friendNick
                };

                return foundFriend;
            }
            return new Friend().valueOf(found);
        }

        public Friend AddToFriend(Friend friend) {
            var newFriend = new Friends {
                friendFirstName = friend.FirstName,
                friendLastName = friend.LastName,
                friendNick = friend.NickName
            };

            snookerEnt.Friends.Add(newFriend);
            snookerEnt.SaveChanges();

            return friend;
        }

    }
}