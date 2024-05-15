using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>
    {
        public Admin Create(Admin obj)
        {
            db.Admins.Add(obj);
            if(db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> Read()
        {
            throw new NotImplementedException();
        }

        public Admin Read(int id)
        {
            throw new NotImplementedException();
        }

        public Admin Update(Admin obj)
        {
            throw new NotImplementedException();
        }
    }
}
