using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Models
{
    public class MovieDBContext: DbContext
    {
        public DbSet<Movie> Movies { get; set;} 
        public DbSet<Character> Characters { get; set;}
        public DbSet<Franchise> Franchises { get;set;}

        public MovieDBContext(DbContextOptions options) : base(options) 
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "The momory",
                    Genre = "Action",
                    Year = 2021,
                    Director = "David",
                    Picture = "Link",
                    Trailer = "YouTubeLink"
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Bat Man",
                    Genre = "Action",
                    Year = 2020,
                    Director = "John",
                    Picture = "Link",
                    Trailer = "YouTubeLink"
                }
                );

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    CharacterId = 1,
                    FullName = "David Swax",
                    Alias = "HBO",
                    Gender = "Male",
                    Picture = "PicturLink"
                },
                 new Character
                 {
                     CharacterId = 2,
                     FullName = "Sven Swax",
                     Alias = "HBO",
                     Gender = "Female",
                     Picture = "PicturLink"
                 });

            modelBuilder.Entity<Franchise>().HasData(
                new Franchise { FranchiseId = 1, Name = "HBOGothernburg", Description = "Welcome to GothenburgBIO" },
                new Franchise { FranchiseId = 2, Name = "HBOStockholm", Description = "Welcome to StockholmBIO" }
                );

        }
    }
}
