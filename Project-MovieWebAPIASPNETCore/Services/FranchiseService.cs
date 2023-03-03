using Microsoft.EntityFrameworkCore;
using Project_MovieWebAPIASPNETCore.Exceptions;
using Project_MovieWebAPIASPNETCore.Models;
using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieDBContext _context;
        public FranchiseService(MovieDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a list of all the franchises from the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises.Include(m => m.Movies).ToListAsync();
        }

        /// <summary>
        /// Get a Franchise by franchise id from the database asynchronously
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await _context.Franchises.Include(c => c.Movies).SingleOrDefaultAsync(f => f.FranchiseId == id);
            // var character = await _context.Characters.Include(c => c.Movies).SingleOrDefaultAsync(c => c.CharacterId == id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise;
        }

        public async Task<IEnumerable<Movie>> GetAllMovieInFranchiseId(int id)
        {
            return await _context.Movies
            .Include(m => m.Characters)
            .Where(m => m.FranchiseId == id)
            .ToListAsync();
        }

        public async Task UpdateFranchiseMovie(int id, IEnumerable<int> movies)
        {
            Franchise franchiseToUpdateMovie = await _context.Franchises
                .Include(c => c.Movies)
                .Where(c => c.FranchiseId == id)
                .FirstAsync();

            List<Movie> moviesFranchise = new();
            foreach (int movieId in movies)
            {
                Movie movieF = await _context.Movies.FindAsync(movieId);
                if (movieF == null)
                    throw new MovieNotFoundException(id);
                moviesFranchise.Add(movieF);
            }
            franchiseToUpdateMovie.Movies = moviesFranchise;
            await _context.SaveChangesAsync();
        }

        public async Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            var searchFranchise = await _context.Franchises.FindAsync(franchise.FranchiseId);
            if (searchFranchise == null)
            {
                throw new FranchiseNotFoundException(franchise.FranchiseId);
            }
            await _context.SaveChangesAsync();
            return franchise;
        }

        public async Task<Franchise> AddFranchise(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return franchise;
        }

        public async Task<bool> FranchiseExist(int id)
        {
            return await _context.Franchises.AnyAsync(e => e.FranchiseId == id);
        }

        /// <summary>
        /// Add a franchise to the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Franchise> DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new CharacterNotFoundException(id);
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }
       
    }
}
