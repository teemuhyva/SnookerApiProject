using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SnookerApiProject.Controllers
{
    public class UsersController : ApiController
    {
        public UsersController()
        {
        }

        private readonly IUsersService UserService;
        private readonly IFriends FriendService;


        public UsersController(IUsersService UserService, IFriends FriendService) {
            this.UserService = UserService;
            this.FriendService = FriendService;
        }

        
        
        [ActionName("findPlayerByNick")]
        public IHttpActionResult FindPlayerByNick(PlayerProfile playerProfile) {
            var result = UserService.FindPlayerByNick(playerProfile);

            return Ok(result);
        }

        [ActionName("updatePlayer")]
        public IHttpActionResult Put(PlayerProfile user) {
            var result = UserService.UpdateUser(user);
            return Ok(result);
        }

        [ActionName("registerPlayer")]
        public IHttpActionResult Post(PlayerProfile user) {

            if(!user.NickName.Equals("Quest")) {
                user = UserService.RegisterNewUser(user);
            } 
            
            return Ok(user);
        }

        [ActionName("deletePlayer")]
        public IHttpActionResult Delete(PlayerProfile user) {
            var del = UserService.RemovePlayer(user);

            return Ok(del);
        }

        [ActionName("searchFriendAndAddAsFriend")]
        public IHttpActionResult SearchAndAddFriend(PlayerProfile user)
        {
            Friend friend = new Friend();
            var addFriend = UserService.FindPlayerByNick(user);

            FriendService.AddToFriend(friend.ValueOf(addFriend));

            return Ok();
        }
    }
}