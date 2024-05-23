using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<IList<Branch>> GetAllBranchesAsync();
        Task<Branch> GetBranchByIdAsync(int id);
        Task<Branch> GetBranchBySlug(string slug);
        Task<bool> DeleteBranch(int id);
        Task<IList<Branch>> GetLimitBranchByCategory(int limit, string category);
    }
}
