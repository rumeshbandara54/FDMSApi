using FDMSWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace FDMSWebApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Favorite> Favouitemarks { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FoodNutritionMapping> FoodNutritionMapping { get; set; }
        public DbSet<FoodIngrediantMapping> FoodIngrediantMapping { get; set; }
        public DbSet<Nutrition> Nutrition { get; set; }
        public DbSet<Ingrediant> Ingrediant { get; set; }
         
    }
}
