using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.UserServiceImpl {
    public class FriendsServiceImpl : IFriends {

        SnookerApiProject2_dbEntities snookerEnt = new SnookerApiProject2_dbEntities();

        public List<Friend> ListPreviousPlayers()
        {
            Friend friend = new Friend();
            var playersList = (from pList in snookerEnt.Friends
                              select pList).ToList();
            var playerList = friend.ValueOf(playersList);
            return playerList;
        }

        public Friend FindFriendByNick(string nickName) {
            var found = snookerEnt.Friends.SingleOrDefault(p => p.friendNick == nickName);
            if (found != null) {
                var foundFriend = new Friend {
                    FirstName = found.friendFirstName,
                    LastName = found.friendLastName,
                    NickName = found.friendNick
                };
                return new Friend().ValueOf(found);                
            }

            //return new friend object thats null
            return new Friend();

        }

        public void AddToFriend(Friend friend) {
            var alreadyFound = snookerEnt.Friends.SingleOrDefault(p => p.friendNick == friend.NickName);

            if(alreadyFound == null)
            {
                var newFriend = new Friends
                {
                    friendFirstName = friend.FirstName,
                    friendLastName = friend.LastName,
                    friendNick = friend.NickName
                };
                snookerEnt.Friends.Add(newFriend);
                snookerEnt.SaveChanges();
            } else
            {
                throw new Exception("Friend already added");
            }           
        }

        public void DeleteFriend(Friend friend) {
            var delFriend = snookerEnt.Friends.SingleOrDefault(p => p.friendNick == friend.NickName);

            if(delFriend != null) {
                snookerEnt.Friends.Remove(delFriend);
                snookerEnt.SaveChanges();
            }
        }
    }
}