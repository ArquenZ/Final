using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.Entities
{
    public class Game
    {
        public int GameID { get; set; }
        public enum Stages {Groupstage,Quarterfinals,Semifinals, Final };
        public Stages Stage { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

    }
}
