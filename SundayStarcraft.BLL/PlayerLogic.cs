using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SundayStarcraft.BLL.Interfaces;
using SundayStarcraft.DAL.Interfaces;
using SundayStarcraft.Entities;
using SundayStarcraft.DAL;


namespace SundayStarcraft.BLL
{
    public class PlayerLogic:IPlayerLogic
    {
        private IPlayerDao _playerDao;
        public PlayerLogic(IPlayerDao playerDao)
        {
            _playerDao = playerDao;
        }
        public int Add(Player player)
        {
            return _playerDao.Add(player);
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerDao.GetAll();
        }

        public Player GetByID(int id)
        {
            return _playerDao.GetByID(id);
        }
        public void DeleteById(int id)
        {
            _playerDao.DeleteById(id);
        }

        //public IEnumerable<Player> GetAllByRace(Player.Races race)
        //{
        //    return _playerDao.GetAllByRace(race);
        //}
    }
}
