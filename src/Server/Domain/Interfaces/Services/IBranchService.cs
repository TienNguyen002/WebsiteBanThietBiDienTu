using Domain.DTO.Branch;

namespace Domain.Interfaces.Services
{
    public interface IBranchService
    {
        Task<IList<BranchDTO>> GetAllBranches();
        Task<BranchDTO> GetBranchById(int id);
        Task<BranchDTO> GetBranchBySlug(string slug);
        Task<bool> AddOrUpdateBranch(BranchEditModel model);
        Task<bool> DeleteBranch(int id);
        Task<IList<BranchProductDTO>> GetLimitBranchByCategory(int limit, string category);
    }
}
