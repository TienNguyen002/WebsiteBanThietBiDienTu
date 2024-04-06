using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<Tag> GetTagBySlug(string slug);
        Task<bool> DeleteTag(int id);
    }
}
