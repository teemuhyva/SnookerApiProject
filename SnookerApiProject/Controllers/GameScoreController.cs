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
    public class GameScoreController : ApiController
    {

        private readonly IGamesService GamesService;
        public GameScoreController(IGamesService GamesService)
        {
            this.GamesService = GamesService;
        }
        [ActionName("storeGameStats")]
        public IHttpActionResult PostCurrentGameScore(GameStats currentGameStats)
        {
            currentGameStats.GameDate = DateTime.Now;
            GamesService.SaveCurrentGame(currentGameStats);
            return Ok();
        }
    }
}
