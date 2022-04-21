using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Data
{
    public class TestDbContext : DbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sheds ------------------------------------------------
            modelBuilder.Entity<Shed>().HasData(new Shed
            {
                Id = 1,
                Name = "Brown Shed",
                Boxes = new List<Box>()
            });

            // Boxes ------------------------------------------------
            modelBuilder.Entity<Box>().HasData(new Box
            {
                Id = 1,
                Name = "Box 1",
                ShedId = 1,
                Things = new List<Thing>()
            });

            // Things ------------------------------------------------
            modelBuilder.Entity<Thing>().HasData(new Thing
            {
                Id = 1,
                Name = "Spanner",
                BoxId = 1
            });
            modelBuilder.Entity<Thing>().HasData(new Thing
            {
                Id = 2,
                Name = "Wrench",
                BoxId = 1
            });
            modelBuilder.Entity<Thing>().HasData(new Thing
            {
                Id = 3,
                Name = "Screwdriver",
                BoxId = 1
            });
            modelBuilder.Entity<Thing>().HasData(new Thing
            {
                Id = 4,
                Name = "Socket",
                BoxId = 1
            });
        }

        public DbSet<Shed> Sheds { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Thing> Things { get; set; }
    }
}
