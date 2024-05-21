using Domain.DTO.Other;
using Domain.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IOtherService
    {
        Task<bool> AddFeedback(FeedbackEditModel model);
        Task<ProductFilter> GetProductFiltersAsync();
    }
}
