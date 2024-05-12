using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DeliveryBoyProfileRepo : Repo, IRepo<DeliveryBoyProfile, int, DeliveryBoyProfile>
    {
        public DeliveryBoyProfile Create(DeliveryBoyProfile obj)
        {
            db.DeliveryBoyProfiles.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.DeliveryBoyProfiles.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<DeliveryBoyProfile> Read()
        {
            return db.DeliveryBoyProfiles.ToList();
        }

        public DeliveryBoyProfile Read(int id)
        {
            return db.DeliveryBoyProfiles.Find(id);
        }

        public DeliveryBoyProfile Update(DeliveryBoyProfile obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
