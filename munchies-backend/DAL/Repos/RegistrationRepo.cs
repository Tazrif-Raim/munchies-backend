using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RegistrationRepo : Repo, IRepo<Registration, int, Registration>
    {
        public Registration Create(Registration obj)
        {
            db.Registrations.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var existing = Read(id);
            if (existing != null)
            {
                db.Registrations.Remove(existing);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<Registration> Read()
        {
            return db.Registrations.ToList();
        }

        public Registration Read(int id)
        {
            return db.Registrations.Find(id);
        }

        public Registration Update(Registration obj)
        {
            var existing = Read(obj.RegistrationId); // Assuming RegistrationId is the identifier in the Registration model
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0) return obj;
            }
            return null;
        }
    }
}
