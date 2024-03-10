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
        //Lấy danh sách comment
        Task<IList<CommentItems>> GetCommentsAsync(CancellationToken cancellationToken = default);

        //Lấy ds comment bằng Slug sản phẩm
        Task<Comment> GetCommentsByProductSlugAsync(string slug, bool includeDetails = false, CancellationToken cancellationToken = default);

        //Thêm comment
        Task<bool> AddCommentAsync(Comment comment, string productSlug, CancellationToken cancellationToken = default);

        //Xóa comment
        Task<bool> DeleteCommentByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
