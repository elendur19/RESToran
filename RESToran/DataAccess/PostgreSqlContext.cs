using Microsoft.EntityFrameworkCore;
using RESToran.Models;

namespace RESToran.DataAccess
{ 
    public class PostgreSqlContext: DbContext
    {
        //private readonly string _connectionString;

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
