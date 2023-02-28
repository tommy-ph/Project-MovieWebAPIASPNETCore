using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> DeleteMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
    }
}
