using DAL.EF.Models;
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
    internal class userRepo : Repo, IRepo<user, int, user>, IAuth
    {
        public user Authentication(string username, string password)
        {
            user obj = (from u in db.users
                        where u.username.Equals(username) && u.password.Equals(password)
                        select u).SingleOrDefault();
            return obj;
        }

        public List<user> Read()
        {
            return db.users.ToList();
        }

        public user Create(user obj)
        {
            db.users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int key)
        {
            var exObj = db.users.Find(key);
            db.users.Remove(exObj);
            return db.SaveChanges() > 0;
        }

        public user Read(int key)
        {
            return db.users.Find(key);
        }

        public user Update(user obj)
        {
            db.users.AddOrUpdate(obj);
            return (db.SaveChanges() > 0) ? obj : null;
        }
    }
}
