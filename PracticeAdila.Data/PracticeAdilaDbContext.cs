using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PracticeAdila.Domain;

namespace PracticeAdila.Data
{
    public class PracticeAdilaDbContext : IdentityDbContext<User, Role, int>
    {
        public PracticeAdilaDbContext() : base()
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public PracticeAdilaDbContext(DbContextOptions options) : base(options) {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Data Source=.;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            // previous string:
            // optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PracticeAdilaDb; Integrated Security = True");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Other possible methods:
            // .HasColumnName(“sName”)
            // .HasColumnType(“varchar”)
            // .HasColumnOrder(2)
            // HasMaxLength(255);
            // Are there any more important ones I'm missing?
            // modelBuilder.Entity<Review>().Property(review => review.ReviewerName).IsRequired();

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    City = "Hasselt",
                    Country = "Belgium",
                    Name = "Luigi's"
                });
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 2,
                    City = "Sint-Truiden",
                    Country = "Belgium",
                    Name = "Bombasta"
                });
            
        }
    }
}
