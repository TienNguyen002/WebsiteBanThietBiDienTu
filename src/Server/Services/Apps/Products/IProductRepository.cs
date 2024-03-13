using Core.Contracts;
using Core.DTO.Product;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Products
{
    public interface IProductRepository
    {
        //Lấy ds sản phẩm (phân trang)
        Task<IPagedList<T>> GetPagedProductAsync<T>(ProductQuery query,
            IPagingParams pagingParams,
            Func<IQueryable<Product>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);

        //Lấy sản phẩm bằng id
        Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);

        //Kiểm tra slug
        Task<bool> IsProductExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default);

        //Lấy sản phẩm bằng slug
        Task<Product> GetProductBySlugAsync(string slug, CancellationToken cancellationToken = default);

        //Lấy tất cả sản phẩm bằng tag
        Task<IList<ProductItems>> GetProductsByTagAsync(string tag, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật sản phẩm
        Task<bool> AddOrUpdateProductAsync(Product product, CancellationToken cancellationToken = default);

        //Xóa sản phẩm
        Task<bool> DeleteProduct(int id, CancellationToken cancellationToken = default);
    }
}
