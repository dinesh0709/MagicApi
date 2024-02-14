using MagicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }// this method is used to use basic features of DbContext class.
        public DbSet<Villa> Villas { get; set; }//here villas be table name of database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>()/*.HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Dino",
                    Details = "adsdghjgjgjhgj",
                    ImageUrl = "www.google.com.jpg",
                    Occupancy = 55,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate= DateTime.Now
                },
                new Villa
                {
                    Id = 2,
                    Name = "Ron",
                    Details = "ccccccccccccccc",
                    ImageUrl = "www.google.com",
                    Occupancy = 8,
                    Rate = 500,
                    Sqft = 600,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                })*/;
        }
    }
}
