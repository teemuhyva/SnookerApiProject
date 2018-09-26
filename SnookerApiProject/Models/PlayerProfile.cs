using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Models {
    public class PlayerProfile {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String NickName { get; set; }
        public int IsHidden { get; set; }
        public int IsPublic { get; set; }
        public int IsFriendsOnly { get; set; }

        public PlayerProfile CheckEmptyFields(PlayerProfile player, UserProfile user) {
            PlayerProfile playerProfile = new PlayerProfile();

            if(player.FirstName == null) {
                player.FirstName = user.firstName;
            }

            if(player.LastName == null) {
                player.LastName = user.lastName;
            }

            if (player.NickName == null) {
                player.LastName = user.lastName;
            }

            return playerProfile;
        }

    }
}