using SundayStarcraft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SundayStarcraft.DAL.Interfaces
{
    public interface IAdminDao
    {
        int Add(Admin admin);
        Admin GetByID(int id);
        IEnumerable<Admin> GetAll();
        void DeleteById(int id);
        
    }
}
