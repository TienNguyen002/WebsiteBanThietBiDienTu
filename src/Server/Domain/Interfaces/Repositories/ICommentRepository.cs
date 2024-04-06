using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        public Task<IList<Comment>> GetCommentsByProductTag(string tag);
    }
}
