using Core.Contracts;
using Core.DTO.Color;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Colors
{
    public interface IColorRepository
    {
        //Lấy danh sách màu sản phẩm (phân trang)
        Task<IPagedList<T>> GetPagedColorAsync<T>(ColorQuery query, 
            IPagingParams pagingParams,
            Func<IQueryable<Color>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);

        //Lấy màu bằng id
        Task<Color> GetColorByIdAsync(int id, CancellationToken cancellationToken = default);

        //Kiểm tra slug
        Task<bool> IsColorExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default);

        //Lấy màu bằng slug
        Task<Color> GetColorBySlugAsync(string slug, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật màu
        Task<bool> AddOrUpdateColorAsync(Color color, CancellationToken cancellationToken = default);

        //Xóa màu
        Task<bool> DeleteColor(int id, CancellationToken cancellationToken = default);
    }
}
