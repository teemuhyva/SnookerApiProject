using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.UserServiceImpl {
    public class FriendsServiceImpl : IFriends {

        SnookerAppEntitie3 snookerEnt = new SnookerAppEntitie3();

        public Friend FindFriendByNick(string nickName) {
            var found = snookerEnt.Players.SingleOrDefault(p => p.nickName == nickName);

            Friend foundFriend = new Friend {
                FirstName = found.firstName,
                LastName = found.lastName,
                NickName = found.nickName
            };

            return foundFriend; 
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