using SnookerApiProject.Models;
using SnookerApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.GamesServImpl
{
    public class GameServiceImpl : IGamesService
    {
        SnookerApiProject2_dbEntities snookerEnt = new SnookerApiProject2_dbEntities();
        public void SaveCurrentGame(GameStats currentGameStats)
        {
            var currentGame = new GameStatistics
            {
                player1 = currentGameStats.Player1,
                player2 = currentGameStats.Player2,
                BestOf = currentGameStats.BestOf,
                scorePlayer1 = currentGameStats.ScorePlayer1,
                scorePlayer2 = currentGameStats.ScorePlayer2,
                topBreakPlayer1 = currentGameStats.TopBreakPlayer1,
                topBreakPlayer2 = currentGameStats.TopBreakPlayer2,
                winningPlayer = currentGameStats.WinningPlayer,
                gameNumber = currentGameStats.GameNumber,
                gameDate = currentGameStats.GameDate
            };

            snookerEnt.GameStatistics.Add(currentGame);
            snookerEnt.SaveChanges();
            
        }
    }
}