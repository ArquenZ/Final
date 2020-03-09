using SundayStarcraft.DAL;
using SundayStarcraft.BLL.Interfaces;
using SundayStarcraft.DAL.Interfaces;
using SundayStarcraft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.BLL
{

    public class AdminLogic : IAdminLogic
    {
        private IAdminDao _adminDao;
        public AdminLogic(IAdminDao adminDao)
        {
            _adminDao = adminDao;
        }
        public int Add(Admin admin)
        {
            return _adminDao.Add(admin);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _adminDao.GetAll();
        }

        public Admin GetByID(int id)
        {
            return _adminDao.GetByID(id);
        }
        public void DeleteById(int id)
        {
           _adminDao.DeleteById(id);
        }
    }
}
