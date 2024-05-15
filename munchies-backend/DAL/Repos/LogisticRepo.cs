using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repos
{
    internal class LogisticRepo : Repo, IRepo<Logistic, int, Logistic>
    {
        public Logistic Create(Logistic obj)
        {
            db.Logistics.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Logistics.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Logistic> Read()
        {
            return db.Logistics.ToList();
        }

        public Logistic Read(int id)
        {
            return db.Logistics.Find(id);
        }

        public Logistic Update(Logistic obj)
        {
            var ex = Read(obj.id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
