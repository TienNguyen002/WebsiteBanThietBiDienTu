using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<Branch> GetBranchBySlug(string slug);
        Task<bool> AddOrUpdateBranch(Branch branch);
        Task<bool> DeleteBranch(int id);
    }
}
