using Core.Contracts;
using Core.DTO.Order;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Orders
{
    public interface IOrderRepository
    {
        //Lấy ds đơn hàng (phân trang)
        Task<IPagedList<T>> GetPagedOrderAsync<T>(OrderQuery query,
            IPagingParams pagingParams,
            Func<IQueryable<Order>, IQueryable<T>> mapper,
            CancellationToken cancellationToken = default);

        //Lấy đơn hàng bằng id
        Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật đơn hàng
        Task<bool> AddOrderAsync(Order order, CancellationToken cancellationToken = default);

        //Xóa đơn hàng
        Task<bool> DeleteOrder(int id, CancellationToken cancellationToken = default);
    }
}
