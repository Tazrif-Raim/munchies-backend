using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{

    internal class StockTableRepo : Repo, IRepo<StockTable, int, StockTable>
    {
        public StockTable Create(StockTable obj)
        {
            db.StockTables.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.StockTables.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<StockTable> Read()
        {
            return db.StockTables.ToList();
        }

        public StockTable Read(int id)
        {
            return db.StockTables.Find(id);
        }

        public StockTable Update(StockTable obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}

