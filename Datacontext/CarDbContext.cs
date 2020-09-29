using Datacontext.Models;
using Microsoft.EntityFrameworkCore;

namespace Datacontext
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public CarDbContext()
            : base()
        {

        }

        public CarDbContext(DbContextOptions<CarDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarsDB.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }
    }
}
