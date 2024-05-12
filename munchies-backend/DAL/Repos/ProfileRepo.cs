using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProfileRepo : Repo, IRepo<Profile, int, Profile>
    {
        public Profile Create(Profile obj)
        {
            db.Profiles.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Profiles.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Profile> Read()
        {
            return db.Profiles.ToList();
        }

        public Profile Read(int id)
        {
            return db.Profiles.Find(id);
        }

        public Profile Update(Profile obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
