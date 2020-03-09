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
    public static class AdminIoc
    {
        public static IAdminDao AdminDao { get; set; } = new AdminDao();
        public static IAdminLogic AdminLogic { get; set; } = new AdminLogic(AdminDao);
    }
}
