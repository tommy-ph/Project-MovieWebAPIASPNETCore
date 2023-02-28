using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Exceptions;
using Project_MovieWebAPIASPNETCore.Models;
using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public class MovieService : IMovieService
    {
        //Injection the DbContext here
        private readonly MovieDBContext _context;

        public MovieService(MovieDBContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
           _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
               throw new MovieNotFoundException(id);
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }
            return movie;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var searchMovie = await _context.Movies.FindAsync(movie.MovieId);
            if (searchMovie == null)
            {
                throw new MovieNotFoundException(movie.MovieId);
            }
           // _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
