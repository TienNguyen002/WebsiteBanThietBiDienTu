using Domain.DTO.Comment;

namespace Domain.Interfaces.Services
{
    public interface ICommentService
    {
        Task<bool> AddComment(CommentEditModel model);  
        Task<IList<CommentDTO>> GetCommentsByProductSlug(string slug);
        Task<CommentCountDTO> CountAllComment(string slug);
    }
}
