using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ChangeMobileBankingNumberRepo : Repo, IRepo<ChangeMobileBankingNumber, int, ChangeMobileBankingNumber>
    {
        public ChangeMobileBankingNumber Create(ChangeMobileBankingNumber obj)
        {
            db.ChangeMobileBankingNumbers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ChangeMobileBankingNumber> Read()
        {
            return db.ChangeMobileBankingNumbers.ToList();
        }

        public ChangeMobileBankingNumber Read(int id)
        {
            return db.ChangeMobileBankingNumbers.Find(id);
        }

        public ChangeMobileBankingNumber Update(ChangeMobileBankingNumber obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
