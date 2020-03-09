using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.Entities
{
    public class Tournament
    {
        public List<Player> Players { get; set; }
        public int TournamentID { get; set; }
        public string Name { get; set; }
        public List<Game> MatchHistory { get; set; }
       
    }
}
