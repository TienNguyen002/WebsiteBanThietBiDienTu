using Core.DTO.Category;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Categories
{
    public interface ICategoryRepository
    {
        //Lấy tất cả danh mục
        Task<IList<CategoryItems>> GetAllCategoryAsync(CancellationToken cancellationToken = default);

        //Kiểm tra danh mục tồn tại
        Task<bool> IsCategoryExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default);

        //Lấy danh mục bằng Id
        Task<Category> GetCategoryByIdAsync(int id, bool includeDetails = false, CancellationToken cancellationToken = default);

        //Lấy danh mục bằng Slug
        Task<Category> GetCategoryBySlugAsync(string slug, bool includeDetails = false, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật danh mục
        Task<bool> AddOrUpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);

        //Xóa danh mục
        Task<bool> DeleteCategoryByIdAsync(int id,  CancellationToken cancellationToken = default);
    }
}
