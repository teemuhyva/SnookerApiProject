using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Models {
    public class Friend {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String NickName { get; set; }
        public int ViewHistory { get; set; }
        public int ViewBreaks { get; set; }

        public String Message { get; set; }

        public Friend ValueOf(Friends friends) {
            Friend friend = new Friend
            {
                FirstName = friends.friendFirstName,
                LastName = friends.friendLastName,
                NickName = friends.friendNick
            };

            return friend;
        }
        public Friend ValueOf(PlayerProfile player)
        {
            Friend friend = new Friend {
                FirstName = player.FirstName,
                LastName = player.LastName,
                NickName = player.NickName
            };

            return friend;
        }
        public List<Friend> ValueOf(List<Friends> friends)
        {
            List<Friend> listFriend = new List<Friend>();
            foreach(Friends name in friends)
            {
                Friend friend = new Friend
                {
                    //TODO: Create separate table for registered users and get nick from there
                    //now using friend table
                    NickName = name.friendNick
                };

                listFriend.Add(friend);
            }

            return listFriend;
        }
    }
}