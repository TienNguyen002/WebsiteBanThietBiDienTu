using Core.DTO.SpecificationCategory;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.SpecificationCategories
{
    public interface ISpecificationCategoryRepository
    {
        //Lấy ds danh mục thuộc tính
        Task<IList<SpecificationCategoryItems>> GetAllSpecificationCategoriesAsync(CancellationToken cancellationToken = default);

        //Lấy danh mục thuộc tính bằng id
        Task<SpecificationCategory> GetSpecificationCategoryByIdAsync(int id, CancellationToken cancellationToken = default);

        //Lấy danh mục thuộc tính bằng slug
        Task<SpecificationCategory> GetSpecificationCategoryBySlugAsync(string slug, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật danh mục thuộc tính
        Task<bool> AddOrUpdateSpecificationCategoryAsync(SpecificationCategory specificationCategory, CancellationToken cancellationToken = default);

        //Xóa danh mục thuộc tinh
        Task<bool> DeleteSpecificationCategoryAsync(int id, CancellationToken cancellationToken = default);

        //Kiểm tra slug
        Task<bool> IsSpecificationCategoryExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default);
    }
}
