using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BrandRepo : Repo, IRepo<Brand, Guid, Brand>
    {
        public Brand Create(Brand obj)
        {
            db.Brands.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Guid id)
        {
            var ex = Read(id);
            db.Brands.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Brand> Read()
        {
            return db.Brands.ToList();
        }

        public Brand Read(Guid id)
        {
            return db.Brands.Find(id);
        }

        public Brand Update(Brand obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
