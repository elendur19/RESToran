using RESToran.Models;
using Microsoft.EntityFrameworkCore;

namespace RESToran.DataAccess
{ 
    public class PostgreSqlContext: DbContext
    {
        //private readonly string _connectionString;

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Dish> Dish { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        public DbSet<RESToran.Models.ReservationPeriod> ReservationPeriod { get; set; }

    }
}
