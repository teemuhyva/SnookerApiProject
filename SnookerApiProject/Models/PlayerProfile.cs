using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Models {
    public class PlayerProfile {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String NickName { get; set; }
        public Boolean IsHidden { get; set; }
        public Boolean IsPublic { get; set; }
        public Boolean IsFriendsOnly { get; set; }
    }
}