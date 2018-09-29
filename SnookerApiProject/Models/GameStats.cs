using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnookerApiProject.Models
{
    public class GameStats
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int BestOf { get; set; }
        public int ScorePlayer1 { get; set; }
        public int ScorePlayer2 { get; set; }
        public int TopBreakPlayer1 { get; set; }
        public int TopBreakPlayer2 { get; set; }
        public string WinningPlayer { get; set; }
        public int GameNumber { get; set; }
        public DateTime GameDate { get; set; }
    }
}