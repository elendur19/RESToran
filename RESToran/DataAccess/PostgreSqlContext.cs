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

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<ReservationPeriod> ReservationPeriod { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // postavi unique constraint nad tableNumber field-om Table-a
            builder.Entity<Table>()
            .HasIndex(t => t.RestName_Number)
            .IsUnique();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}
