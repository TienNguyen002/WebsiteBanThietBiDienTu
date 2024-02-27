using Core.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Categories
{
    public interface ICategoryRepository
    {
        Task<IList<CategoryItems>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);


    }
}
