using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class tokenRepo : Repo, IRepo<token, int, token>
    {
        public List<token> Read()
        {
            return db.tokens.ToList();
        }

        public token Create(token obj)
        {
            db.tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int key)
        {
            db.tokens.Remove(Read(key));
            return db.SaveChanges() > 0;
        }

        public token Read(int key)
        {
            return db.tokens.Find(key);
        }

        public token Update(token obj)
        {
            db.tokens.AddOrUpdate(obj);
            return (db.SaveChanges() > 0) ? obj : null;
        }
    }
}
