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
        /// Add a franchise to the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Franchise> AddFranchise(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();

            return franchise;
        }

        public Task<Franchise> DeleteFranchise(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a list of all the franchises from the database
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises.ToListAsync();
        }

        /// <summary>
        /// Get a Franchise by franchise id from the database asynchronously
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise;
        }
     

        public Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            throw new NotImplementedException();
        }
    }
}
