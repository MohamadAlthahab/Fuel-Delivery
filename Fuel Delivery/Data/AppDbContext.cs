using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fuel_Delivery.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Driver> Diver { get; set; }
        public DbSet<Fuel> Fuel { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Car> Car { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.ApplyConfiguration(new Role());

            builder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Phone = "0933600500",
                    Password = "Admin",
                });
        }
    }
}
