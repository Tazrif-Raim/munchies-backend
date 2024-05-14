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

        public static IRepo<ChatUser, string, ChatUser> ChatUserData()
        {
               return new ChatUserRepo();
        }

        public static IRepo<serverPass, string, serverPass> serverPassData()
        {
            return new ServerPassRepo();
        }

        public static IRepo<Review, int, Review> ReviewData()
        {
            return new ReviewRepo();
        }

        public static IRepo<OrderLocation, int, OrderLocation> OrderLocationData()
        {
            return new OrderLocationRepo();
        }
        public static IRepo<ChangeMobileBankingNumber, int, ChangeMobileBankingNumber> ChangeMobileBankingNumberData()
        {
            return new ChangeMobileBankingNumberRepo();
        }
        public static IRepo<Registration, int, Registration> RegistrationData()
        {
            return new RegistrationRepo();
        }
        public static IRepo<CreateUser,  int, CreateUser> CreateUserData()
        {
            return new CreateUserRepo();
        }

        public static IRepo<StockTable, int, StockTable> StockTableData()
        {
            return new StockTableRepo();
        }

        public static IRepo<Logistic, int, Logistic> LogisticData()
        {
            return new LogisticRepo();
        }
    }
}
