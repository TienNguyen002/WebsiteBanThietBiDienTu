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
        Task<IList<CategoryItems>> GetAllCategoryAsync(CancellationToken cancellationToken = default);

        Task<bool> IsCategoryExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default);

        Task<Category> GetCategoryByIdAsync(int id, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<Category> GetCategoryBySlugAsync(string slug, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<bool> AddOrUpdateCategoryAsync(Category category, CancellationToken cancellationToken = default);

        Task<bool> DeleteCategoryByIdAsync(int id,  CancellationToken cancellationToken = default);
    }
}
