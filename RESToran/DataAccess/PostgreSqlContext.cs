using RESToran.Models;
using Microsoft.EntityFrameworkCore;

namespace RESToran.DataAccess
{ 
    // IdentityDbContext contains all the restaurant tables
    public class PostgreSqlContext: DbContext
    {
        //private readonly string _connectionString;

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<ReservationPeriod> ReservationPeriod { get; set; }
        public DbSet<Appetizer> Appetizer { get; set; }
        public DbSet<MainCourse> MainCourse { get; set; }
        public DbSet<Dessert> Dessert { get; set; }
        public DbSet<Salad> Salad { get; set; }
        public DbSet<Drink> Drink { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // postavi unique constraint nad Name field-om Restaurant-a
            builder.Entity<Restaurant>()
            .HasIndex(r => r.Name)
            .IsUnique();
            // i email adresu
            builder.Entity<Restaurant>()
            .HasIndex(r => r.EmailAddress)
            .IsUnique();

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
