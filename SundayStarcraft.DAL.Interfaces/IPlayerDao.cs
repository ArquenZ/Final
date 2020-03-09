using SundayStarcraft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SundayStarcraft.Entities.Player;

namespace SundayStarcraft.DAL
{
    public interface IPlayerDao
    {
        int Add(Player player);
        Player GetByID(int id);
        IEnumerable<Player> GetAll();
        //IEnumerable<Player> GetAllByRace(Races race);
        void DeleteById(int id);
    }
}
