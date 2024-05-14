using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CreateUserRepo : Repo, IRepo<CreateUser, int, CreateUser>
    {
        public CreateUser Create(CreateUser obj)
        {
            db.CreateUsers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.CreateUsers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<CreateUser> Read()
        {
            return db.CreateUsers.ToList();
        }

        public CreateUser Read(int id)
        {
            return db.CreateUsers.Find(id);
        }

        public CreateUser Update(CreateUser obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
