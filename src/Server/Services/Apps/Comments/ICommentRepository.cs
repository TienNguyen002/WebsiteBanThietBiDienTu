using Core.DTO.Comment;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Comments
{
    public interface ICommentRepository
    {
        Task<IList<CommentItems>> GetCommentsAsync(CancellationToken cancellationToken = default);

        Task<IList<CommentItems>> GetCommentsByProductSlugAsync(string slug, CancellationToken cancellationToken = default);

        Task<bool> AddCommentAsync(Comment comment, string productSlug, CancellationToken cancellationToken = default);

        Task<bool> DeleteCommentByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
