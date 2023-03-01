using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Models
{
    public static class SeedData
    {
        public static IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                //The Lords of the Ring
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
                    Title = "The Hobbit: The Battle of the Five Armies",
                    Genre = "Action",
                    Year = 2014,
                    Director = "Peter Jackson",
                    Picture = "https://upload.wikimedia.org/wikipedia/en/0/0e/The_Hobbit_-_The_Battle_of_the_Five_Armies.jpg",
                    Trailer = "https://www.youtube.com/watch?v=DxOvAs_SPvA",
                    FranchiseId= 1,
                },
                //Game of Thrones
                new()
                {
                    MovieId = 3,
                    Title = "Game of Thrones Season 1",
                    Genre = "Action",
                    Year = 2011,
                    Director = "Jeremy Podeswa",
                    Picture = "https://upload.wikimedia.org/wikipedia/en/e/e8/Game_of_Thrones_Season_1.jpg",
                    Trailer = "https://www.youtube.com/watch?v=REasBBiJm00",
                    FranchiseId= 2,
                },
                new()
                {
                    MovieId = 4,
                    Title = "Game of Thrones Season 2 ",
                    Genre = "Action",
                    Year = 2012,
                    Director = "Jeremy Podeswa",
                    Picture = "https://letstalkcinemamovie.files.wordpress.com/2019/03/season-2.jpg",
                    Trailer = "https://www.youtube.com/watch?v=hkjb-NEQjnk",
                    FranchiseId= 2,
                },
                new()
                {
                    MovieId = 5,
                    Title = "Maze Runner 1",
                    Genre = "Action",
                    Year = 2018,
                    Director = "Wes Ball",
                    Picture = "https://d2iltjk184xms5.cloudfront.net/uploads/photo/file/327788/7560e35531bfc0aedca67ebde8156d6b-cure-poster.jpg",
                    Trailer = "https://www.youtube.com/watch?v=FPZ3cWWnB_g",
                    FranchiseId= 1,
                },
                new()
                {
                    MovieId = 6,
                    Title = "Maze Runner 1",
                    Genre = "Action",
                    Year = 2018,
                    Director = "Wes Ball",
                    Picture = "https://i.ytimg.com/vi/-44_igsZtgU/maxresdefault.jpg",
                    Trailer = "https://www.youtube.com/watch?v=E8IOB2USpMQ",
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
                     FullName = "Aragorn II Elessar",
                     Alias = "Aragorn",
                     Gender = "Male",
                     Picture = "https://static.wikia.nocookie.net/jadensadventures/images/4/43/Aragorn3.jpg/revision/latest?cb=20140114165013"
                },
                new()
                {
                     CharacterId = 2,
                     FullName = "Galadriel Stineman",
                     Alias = "Galadriel",
                     Gender = "Male",
                     Picture = "https://cdn.vox-cdn.com/thumbor/o9vHcxXd56YpUuoysEaC3YsVKco=/1400x1050/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/23981590/RPAZ_S1_UT_210709_GRAMAT_00291_R2.jpg"
                },
                new()
                {
                     CharacterId = 3,
                     FullName = "Kit Harington",
                     Alias = "Jon Snow",
                     Gender = "Male",
                     Picture = "https://static.hbo.com/content/dam/hbodata/series/game-of-thrones/character/s5/john-snow-1920.jpg?w=960"
                },
                new()
                {
                     CharacterId = 4,
                     FullName = "EMILIA CLARKE",
                     Alias = "Daenerys Targaryen",
                     Gender = "Male",
                     Picture = "https://static.hbo.com/content/dam/hbodata/series/game-of-thrones/character/s5/daenarys-1920.jpg?w=960"
                },
                new()
                {
                    CharacterId = 5,
                    FullName = "Thomas Brodie",
                    Alias = "Newt",
                    Gender = "Male",
                    Picture = "https://flxt.tmsimg.com/assets/294818_v9_bc.jpg"
                },
                new()
                {
                     CharacterId = 6,
                     FullName = "Ki Hong Lee",
                     Alias = "Minho",
                     Gender = "Male",
                     Picture = "https://static.wikia.nocookie.net/vsbattles/images/a/a7/Minho.jpg/revision/latest?cb=20191010095625"
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
