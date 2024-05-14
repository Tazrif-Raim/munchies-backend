using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class MunchiesDbContext : DbContext
    { 
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DeliveryBoyProfile> DeliveryBoyProfiles { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<serverPass> serverPasses { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderLocation> OrderLocations { get; set; }
        public DbSet<ChangeMobileBankingNumber> ChangeMobileBankingNumbers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<CreateUser> CreateUsers { get; set; }
        public DbSet<StockTable> StockTables { get; set; }
        public DbSet<Logistic> Logistics { get; set; }
    }
}
