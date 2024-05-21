using Domain.DTO.Product;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IOtherRepository
    {
        Task<bool> AddNofication(Notification notification);
        Task<bool> AddFeedback(Feedback feedback);
        Task<ProductFilter> GetProductFiltersAsync();
    }
}
