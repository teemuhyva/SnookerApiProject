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

        public UsersController(IUsersService UserService)
        {
            this.UserService = UserService;
        }
        // GET api/<controller>
        public User Get(string name)
        {

            return UserService.GetUserWithName(name);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
    }
}