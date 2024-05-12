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
    /*public class MealRepo
    {
        static MealContext mealContext;
        static MealRepo()
        {
            mealContext = new MealContext();
        }
        public static List<Meal> Get()
        {
            return mealContext.Meals.ToList();
        }
        public static Meal Get(int id) { return mealContext.Meals.Find(id); }
        public static bool Create(Meal meal) 
        { 
            mealContext.Meals.Add(meal);
            return mealContext.SaveChanges() > 0;
        
        }
        public static bool Update(Meal meal) 
        {
            var exmeal = mealContext.Meals.Find(meal.Id);
            mealContext.Entry(exmeal).CurrentValues.SetValues(meal);
            return mealContext.SaveChanges() > 0;
        }
        public static bool Delete(int id) 
        {
            var exmeal = Get(id);
            mealContext.Meals.Remove(exmeal);
            return mealContext.SaveChanges() > 0;

        
        }


    }*/
    internal class MealRepo : Repo, IRepo<Meal, int, Meal>
    {
        /*public List<Meal> Get()
        {
            return db.Meals.ToList();
        }*/
        public Meal Get(int id)
        {
            return db.Meals.Find(id);
        }
        public Meal Create(Meal obj)
        {
            db.Meals.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Meals.Remove(ex);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<Meal> Read()
        {
            return db.Meals.ToList();
        }

        public Meal Read(int id)
        {
            return db.Meals.Find(id);
        }

        public Meal Update(Meal obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
