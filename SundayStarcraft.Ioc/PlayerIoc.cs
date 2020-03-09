using SundayStarcraft.BLL;
using SundayStarcraft.BLL.Interfaces;
using SundayStarcraft.DAL;
using SundayStarcraft.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.Ioc
{
    public static class PlayerIoc
    {
        public static IPlayerDao PlayerDao { get; set; } = new PlayerDao();
        public static IPlayerLogic PlayerLogic { get; set; } = new PlayerLogic(PlayerDao);
    }
}