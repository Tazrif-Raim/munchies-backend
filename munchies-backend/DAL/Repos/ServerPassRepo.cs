using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ServerPassRepo : Repo, IRepo<serverPass, string, serverPass>
    {
        public serverPass Create(serverPass obj)
        {
            db.serverPasses.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.serverPasses.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<serverPass> Read()
        {
            throw new NotImplementedException();
        }

        public serverPass Read(string id)
        {
            return db.serverPasses.Find(id);
        }

        public serverPass Update(serverPass obj)
        {
            throw new NotImplementedException();
        }
    }
}
