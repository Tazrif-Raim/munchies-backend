using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class IngredientRepo : Repo, IRepo<Ingredient, Guid, Ingredient>
    {
        public Ingredient Create(Ingredient obj)
        {
            db.Ingredients.Add(obj);
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Ingredient> Read()
        {
            throw new NotImplementedException();
        }

        public Ingredient Read(Guid id)
        {
            return db.Ingredients.Find(id);
        }

        public Ingredient Update(Ingredient obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
