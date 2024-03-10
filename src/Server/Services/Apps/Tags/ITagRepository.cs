using Core.DTO.Tag;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Tags
{
    public interface ITagRepository
    {
        //Lấy ds tag thuộc tính
        Task<IList<TagItems>> GetAllTagsAsync(CancellationToken cancellationToken = default);

        //Lấy tag thuộc tính bằng id
        Task<Tag> GetTagByIdAsync(int id, CancellationToken cancellationToken = default);

        //Lấy tag thuộc tính bằng slug
        Task<Tag> GetTagBySlugAsync(string slug, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật tag thuộc tính
        Task<bool> AddOrUpdateTagAsync(Tag tag, CancellationToken cancellationToken = default);

        //Xóa tag thuộc tinh
        Task<bool> DeleteTagAsync(int id, CancellationToken cancellationToken = default);

        //Kiểm tra slug
        Task<bool> IsTagExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default);
    }
}
