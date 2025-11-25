using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipes;

namespace AGWADProject.Models
{
    public class AGDbContext : IdentityDbContext<IdentityUser>

    {
        public AGDbContext(DbContextOptions<AGDbContext> options)

        : base(options)

        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TractionType> TractionTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransmissionType>().HasData(
                new TransmissionType { Id = 1, Name = "Automata" },
                new TransmissionType { Id = 2, Name = "Manuala" }
                );
            modelBuilder.Entity<TractionType>().HasData(
                new TractionType { Id = 1, Name = "Fata" },
                new TractionType { Id = 2, Name = "Spate" },
                new TractionType { Id = 3, Name = "Integrala" },
                new TractionType { Id = 4, Name = "4x4" }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Auto" },
                new Category { Id = 2, Name = "Moto" },
                new Category { Id = 3, Name = "Ambarcatiuni" }
                );
            modelBuilder.Entity<FuelType>().HasData(
                new Category { Id = 1, Name = "Benzina" },
                new Category { Id = 2, Name = "Diesel" },
                new Category { Id = 3, Name = "Benzina + GPL" },
                new Category { Id = 4, Name = "Electric" }
                );
        }
    }
}
