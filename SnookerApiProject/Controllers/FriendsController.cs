using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnookerApiProject.Controllers {
    public class FriendsController : ApiController {

        private readonly IFriends FriendService;

        public FriendsController(IFriends FriendService) {
            this.FriendService = FriendService;
        }

        public IHttpActionResult Get(Friend friend) {   
            Friend friendFound = FriendService.FindFriendByNick(friend.NickName);

            if (friendFound.FirstName == null || friendFound.LastName == null || friendFound.NickName == null) {
                throw new Exception("friend not found");
            }

            Friend foundFriend = FriendService.AddToFriend(friendFound);

            return Ok(foundFriend);
        }
        
    }
}