using Dadabase.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dadabase
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasDefaultValueSql("'sample@mail.com'");

            modelBuilder.Entity<Address>()
                .HasData(
                    new Address
                    {
                        Id = 9999,
                        AddressLine1 = "78, Amir Temur",
                        AddressLine2 = "Yunusobod tumani",
                        PostalCode = "70058",
                        City = "Toshkent",
                        Country = "O'zbekiston"
                    }
                );


        }

    }
}