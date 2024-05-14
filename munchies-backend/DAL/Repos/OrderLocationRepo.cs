using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderLocationRepo : Repo, IRepo<OrderLocation, int, OrderLocation>
    {
        public OrderLocation Create(OrderLocation obj)
        {
            db.OrderLocations.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.OrderLocations.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<OrderLocation> Read()
        {
            return db.OrderLocations.ToList();
        }

        public OrderLocation Read(int id)
        {
            return db.OrderLocations.Find(id);
        }

        public OrderLocation Update(OrderLocation obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }

}


