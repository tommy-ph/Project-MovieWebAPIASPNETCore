using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public interface IFranchiseService
    {
        Task<IEnumerable<Franchise>> GetAllFranchises();
        Task<Franchise> GetFranchiseById(int id);
        Task<IEnumerable<Movie>> GetAllMovieInFranchiseId(int id);
        Task UpdateFranchiseMovie(int id, IEnumerable<int> movies);
        Task<Franchise> AddFranchise(Franchise franchise);
        Task<Franchise> UpdateFranchise(Franchise franchise);
        Task<bool> FranchiseExist(int id);
        Task<Franchise> DeleteFranchise(int id);

    }
}
