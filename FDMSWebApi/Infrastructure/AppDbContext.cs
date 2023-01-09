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

        public DbSet<User> Nutrition { get; set; }

        

    }
}
