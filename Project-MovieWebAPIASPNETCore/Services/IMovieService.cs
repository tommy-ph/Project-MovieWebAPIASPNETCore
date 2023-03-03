using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Models.DTOs;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(int id);
        Task<bool> MovieExist(int id);
        Task<IEnumerable<Character>> GetCharactersByMovieId(int id);
        Task UpdateMovieCharactersByMovieId(int id, IEnumerable<int> characterMovieId);
    }
}
