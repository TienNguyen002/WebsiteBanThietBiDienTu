using Core.DTO.User;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Customers
{
    public interface IUserRepository
    {
        Task<IList<UserItems>> GetCustomersAsync(CancellationToken cancellationToken = default);

        Task<User> GetCustomerBySlugAsync(string slug, bool includeDetails = false, CancellationToken cancellationToken = default);
    }
}
