using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Brand, Guid, Brand> BrandData()
        {
            return new BrandRepo();
        }

        public static IRepo<Recipe, Guid, Recipe> RecipeData()
        {
            return new RecipeRepo();
        }

        public static IRepo<Ingredient, Guid, Ingredient> IngredientData()
        {
            return new IngredientRepo();
        }

        public static IRepo<DeliveryBoyProfile, int, DeliveryBoyProfile> DeliveryBoyProfileData()
        {
            return new DeliveryBoyProfileRepo();
        }

        public static IRepo<Meal, int, Meal> MealData()
        {
            return new MealRepo();
        }

        public static IRepo<Profile, int, Profile> ProfileData()
        {
            return new ProfileRepo();
        }
    }
}
