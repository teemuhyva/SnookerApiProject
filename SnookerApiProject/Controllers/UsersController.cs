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

        private readonly IUsersService UserService;

        public UsersController(IUsersService UserService) {
            this.UserService = UserService;
        }

        public IHttpActionResult FindPlayerByNick(PlayerProfile playerProfile) {
            var result = UserService.FindPlayerByNick(playerProfile);

            return Ok(result);
        }

        public IHttpActionResult Put(PlayerProfile user) {
            var result = UserService.UpdateUser(user);
            return Ok(result);
        } 

        public IHttpActionResult Post(PlayerProfile user) {

            if(!user.NickName.Equals("Quest")) {
                user = UserService.RegisterNewUser(user);
            } 
            
            return Ok(user);
        }

        public IHttpActionResult Delete(PlayerProfile user) {
            var del = UserService.RemovePlayer(user);

            return Ok(del);
        }
    }
}