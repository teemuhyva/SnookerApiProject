using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Models {
    public class Friend {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int ViewHistory { get; set; }
        public int ViewBreaks { get; set; }

        public Friend valueOf(Friends friends) {
            Friend friend = new Friend();
            friend.FirstName = friends.friendFirstName;
            friend.LastName = friends.friendLastName;
            friend.NickName = friends.friendNick;
            return friend;
        }
    }
}