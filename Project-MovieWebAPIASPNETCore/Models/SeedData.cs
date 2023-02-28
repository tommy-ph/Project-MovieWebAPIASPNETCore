using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Models
{
    public static class SeedData
    {
        public static IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new()
                {
                    MovieId = 1,
                    Title = "The Lords of the Ring",
                    Genre = "Action",
                    Year = 2022,
                    Director = "Peter Jackson",
                    Picture = "https://nosomosnonos.com/wp-content/uploads/2022/08/A7A70911-8905-4347-BE36-387C8E2E094B.jpeg",
                    Trailer = "https://www.youtube.com/watch?v=uYnQDsaxHZU",
                    FranchiseId= 1,
                },
                new()
                {
                    MovieId = 2,
                    Title = "Bat Man",
                    Genre = "Action",
                    Year = 2020,
                    Director = "Matt Reeves",
                    Picture = "https://www.thebatman.com/images/share.jpg",
                    Trailer = "https://www.youtube.com/watch?v=lpeeXtsATYo",
                    FranchiseId= 2,
                },
                new()
                {
                    MovieId = 3,
                    Title = "Spider Man",
                    Genre = "Action",
                    Year = 2020,
                    Director = "Sam Raimi",
                    Picture = "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_FMjpg_UX1000_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=iaD2f2O9wGk",
                    FranchiseId= 2,
                },
                new()
                {
                    MovieId = 4,
                    Title = "Maze Runner",
                    Genre = "Action",
                    Year = 2018,
                    Director = "Wes Ball",
                    Picture = "https://d2iltjk184xms5.cloudfront.net/uploads/photo/file/327788/7560e35531bfc0aedca67ebde8156d6b-cure-poster.jpg",
                    Trailer = "https://www.youtube.com/watch?v=FPZ3cWWnB_g",
                    FranchiseId= 1,
                }
            };
        }

        public static IEnumerable<Character> GetCharacters()
        {
            return new List<Character>()
            {
                new()
                {
                    CharacterId = 1,
                    FullName = "Thomas Brodie",
                    Alias = "Newt",
                    Gender = "Male",
                    Picture = "https://flxt.tmsimg.com/assets/294818_v9_bc.jpg"
                },
                new()
                {
                     CharacterId = 2,
                     FullName = "Ki Hong Lee",
                     Alias = "Minho",
                     Gender = "Male",
                     Picture = "https://static.wikia.nocookie.net/vsbattles/images/a/a7/Minho.jpg/revision/latest?cb=20191010095625"
                },
                new()
                {
                     CharacterId = 3,
                     FullName = "Aragorn II Elessar",
                     Alias = "Aragorn",
                     Gender = "Male",
                     Picture = "https://static.wikia.nocookie.net/jadensadventures/images/4/43/Aragorn3.jpg/revision/latest?cb=20140114165013"
                },
                new()
                {
                     CharacterId = 4,
                     FullName = "Galadriel Stineman",
                     Alias = "Galadriel",
                     Gender = "Male",
                     Picture = "https://cdn.vox-cdn.com/thumbor/o9vHcxXd56YpUuoysEaC3YsVKco=/1400x1050/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/23981590/RPAZ_S1_UT_210709_GRAMAT_00291_R2.jpg"
                }
            };
        }

        public static IEnumerable<Franchise> GetFranchises() 
        {
            return new List<Franchise>()
            {
                new()
                {
                    FranchiseId = 1,
                    Name = "HBOGothernburg",
                    Description = "Welcome to GothenburgBIO"
                },
                new()
                {
                    FranchiseId = 2, 
                    Name = "HBOStockholm", 
                    Description = "Welcome to StockholmBIO"
                }
            };
        }
    }
}
