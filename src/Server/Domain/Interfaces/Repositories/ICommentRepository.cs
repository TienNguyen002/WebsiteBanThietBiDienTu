using Domain.DTO.Comment;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<IList<Comment>> GetCommentsByProductSlug(string slug);
        Task<CommentCountDTO> CountAllComment(string slug);
    }
}
