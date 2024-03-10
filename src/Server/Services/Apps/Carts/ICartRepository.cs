using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Carts
{
    public interface ICartRepository
    {
        //Lấy giỏ hàng bằng người dùng
        Task<Cart> GetCartByUserSlugAsync(string userSlug, CancellationToken cancellationToken = default);

        //Thêm sản phẩm vào giỏ hàng
        Task<Cart> AddProductToCartAsync(string userSlug, string productSlug, CancellationToken cancellationToken = default);

        //Xóa sản phẩm khỏi giỏ hàng (Update)
        Task<Cart> RemoveProductFromCartAsync(string userSlug, string productSlug, CancellationToken cancellationToken = default);

        //Xóa giỏ hàng
        Task<bool> RemoveCartAsync(string userSlug, CancellationToken cancellationToken = default);
    }
}
