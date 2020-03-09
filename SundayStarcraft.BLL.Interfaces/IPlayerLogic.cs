using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SundayStarcraft.Entities;
using static SundayStarcraft.Entities.Player;

namespace SundayStarcraft.BLL.Interfaces
{
    public interface IPlayerLogic
    {
        int Add(Player player);
        Player GetByID(int id);
        IEnumerable<Player> GetAll();
        //IEnumerable<Player> GetAllByRace(Races race);
        void DeleteById(int id);
    }
}
