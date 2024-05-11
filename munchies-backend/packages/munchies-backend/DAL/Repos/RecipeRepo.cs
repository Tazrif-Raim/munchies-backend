using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RecipeRepo : Repo, IRepo<Recipe, Guid, Recipe>
    {
        public Recipe Create(Recipe obj)
        {
            db.Recipes.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Guid id)
        {
            var ex = Read(id);
            db.Recipes.Remove(ex);
            if(db.SaveChanges()>0) return true;
            return false;
        }

        public List<Recipe> Read()
        {
            return db.Recipes.ToList();
        }

        public Recipe Read(Guid id)
        {
            return db.Recipes.Find(id);
        }

        public Recipe Update(Recipe obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
