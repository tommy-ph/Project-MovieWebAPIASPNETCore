using Project_MovieWebAPIASPNETCore.Models.Domain;

namespace Project_MovieWebAPIASPNETCore.Services
{
    public interface IFranchiseService
    {
        Task<IEnumerable<Franchise>> GetAllFranchises();
        Task<Franchise> GetFranchiseById(int id);
        Task<Franchise> AddFranchise(Franchise franchise);
        Task<Franchise> DeleteFranchise(int id);
        Task<Franchise> UpdateFranchise(Franchise franchise);

    }
}
