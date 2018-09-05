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

        // GET api/<controller>
        //dummy GET method /api/users
        public IHttpActionResult Get() {

            var response = UserService.GetUserWithName();

            if(response == null) {
                return NotFound();
            } else {
                return Ok(response);
            }           
        }

        public IHttpActionResult Post(User user) {
            var result = UserService.RegisterNewUser(user);

            return Ok(result);
        }

        public IHttpActionResult Delete(User user) {
            var del = UserService.RemovePlayer(user);

            return Ok(del);
        }
    }
}