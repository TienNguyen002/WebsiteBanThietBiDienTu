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
        //Lấy ds người dùng
        Task<IList<UserItems>> GetUsersAsync(CancellationToken cancellationToken = default);

        //Lấy người dùng bằng slug
        Task<User> GetUserBySlugAsync(string slug, bool includeDetails = false, CancellationToken cancellationToken = default);

        //Tạo tài khoản

        //Đổi mật khẩu
    }
}
