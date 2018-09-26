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

        [ActionName("previousPlayed")]
        public IHttpActionResult GetListPreviousPlayers()
        {
            return Ok(FriendService.ListPreviousPlayers());
        }

        [ActionName("findFriendByNick")]
        public IHttpActionResult PostFindFriendByNick(Friend friend) {   
            Friend friendFound = FriendService.FindFriendByNick(friend.NickName);

            if (friendFound.FirstName == null || friendFound.LastName == null || friendFound.NickName == null) {
                throw new Exception("friend not found");
            }

            return Ok(friendFound);
        }

        [ActionName("addFriend")]
        public IHttpActionResult PostAddFriend(Friend friend) {
            var friendFound = FriendService.FindFriendByNick(friend.NickName);

            if (friendFound.FirstName == null || friendFound.LastName == null || friendFound.NickName == null)
            {
                throw new Exception("friend not found");
            } else  if (friendFound.NickName != null) {
                //needs exception handling
                friend.Message = "Friend already added to list";
            } else {
                FriendService.AddToFriend(friend);
            }            
            
            return Ok(friendFound);
        }

        [ActionName("removeFriend")]
        public IHttpActionResult Delete(Friend friend) {
            var removeFriend = FriendService.FindFriendByNick(friend.NickName);

            if (removeFriend != null) {
                FriendService.DeleteFriend(friend);
            } else {
                friend.Message = "Friend not found or already removed";
            }

            return Ok(removeFriend);
        }

    }
}