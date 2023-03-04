using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Models
{
    public class MovieDBContext: DbContext
    {
        //Creating tables 
        public DbSet<Movie> Movies { get; set;} 
        public DbSet<Character> Characters { get; set;}
        public DbSet<Franchise> Franchises { get;set;}

        public MovieDBContext(DbContextOptions options) : base(options) 
        { 
           
        }
        //Initial data insert
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defining one-to-many relationships between Franchise and Movie
            // Setting null on delete
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Franchise)
                .WithMany(f => f.Movies)
                .HasForeignKey(m => m.FranchiseId)
                .OnDelete(DeleteBehavior.SetNull);

            //Initialize tables with seed data
            modelBuilder.Entity<Movie>().HasData(SeedData.GetMovies());
            modelBuilder.Entity<Character>().HasData(SeedData.GetCharacters());
            modelBuilder.Entity<Franchise>().HasData(SeedData.GetFranchises());

            //Defining the many-tomany relationships table and inserting data 
            modelBuilder.Entity<Movie>()
                .HasMany(movie => movie.Characters)
                .WithMany(character => character.Movies)
                .UsingEntity<Dictionary<string, object>>(
                 "CharacterMovie",
                 left => left.HasOne<Character>().WithMany().HasForeignKey("CharacterId")!,
                 right => right.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                 joinEntity =>
                 {
                     joinEntity.HasKey("MovieId", "CharacterId");
                     joinEntity.HasData(
                         //The code below sets the relationship between movie and character 
                         //Character David Swax
                         new { MovieId = 1, CharacterId = 1 },
                         new { MovieId = 2, CharacterId = 1 },

                         new { MovieId = 1, CharacterId = 2 },
                         new { MovieId = 2, CharacterId = 2 },


                         new { MovieId = 3, CharacterId = 3 },
                         new { MovieId = 4, CharacterId = 3 },

                         new { MovieId = 3, CharacterId = 4 },
                         new { MovieId = 4, CharacterId = 4 },


                         new { MovieId = 5, CharacterId = 5 },
                         new { MovieId = 6, CharacterId = 5 },

                          new { MovieId = 5, CharacterId = 6 },
                         new { MovieId = 6, CharacterId = 6 }

                         );
                 }
                );
        }
    }
}
