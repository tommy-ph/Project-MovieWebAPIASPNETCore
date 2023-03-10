using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Exceptions;
using Project_MovieWebAPIASPNETCore.Models;
using Project_MovieWebAPIASPNETCore.Models.Domain;
using Project_MovieWebAPIASPNETCore.Models.DTOs;

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

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.Include(c => c.Characters).ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.Include(m => m.Characters).SingleOrDefaultAsync(m => m.MovieId == id);

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
            await _context.SaveChangesAsync();
            return movie;
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
        public async Task<bool> MovieExist(int id)
        {
            return await _context.Movies.AnyAsync(m => m.MovieId == id);
        }

        public async Task<IEnumerable<Character>> GetCharactersByMovieId(int id)
        {
            return await _context.Characters.Include(c => c.Movies).Where(c => c.Movies.Any(m => m.MovieId == id))
            .ToListAsync();
        }

        public async Task UpdateMovieCharactersByMovieId(int id, IEnumerable<int> characterMovieIds)
        {
            var movieUpdate = await GetMovieById(id);
            var newCharacter = new List<Character>();
            foreach (var characterMovieId in characterMovieIds)
            {
                var character = await _context.Characters!.FindAsync(characterMovieId);
                if (character is null)
                {
                    throw new KeyNotFoundException($"Character with id {characterMovieId} not found!");
                }

                newCharacter.Add(character);
            }

            movieUpdate!.Characters = newCharacter;
            await UpdateMovie(movieUpdate);
        }

      
    }
}
