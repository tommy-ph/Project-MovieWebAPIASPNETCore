namespace Project_MovieWebAPIASPNETCore.Models.DTOs.Movies
{
    public class MovieReadDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }

        public List<int> Characters { get; set; }
        public int Franchise { get; set; }
    }
}
