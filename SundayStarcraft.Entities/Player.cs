using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.Entities
{
    public class Player
    {        
        public int PlayerID { get; set; }
        public Races Race { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }  
    }
    public enum Races { Terran = 1, Zerg = 2, Protoss = 3 };
}
