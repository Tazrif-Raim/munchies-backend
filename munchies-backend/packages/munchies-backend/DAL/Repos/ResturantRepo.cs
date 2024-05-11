﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ResturantRepo : Repo, IRepo<Resturant, int, Resturant>
    {
        public Resturant Create(Resturant obj)
        {
            db.Resturants.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Resturants.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Resturant> Read()
        {
            return db.Resturants.ToList();
        }

        public Resturant Read(int id)
        {
            return db.Resturants.Find(id);
        }

        public Resturant Update(Resturant obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
