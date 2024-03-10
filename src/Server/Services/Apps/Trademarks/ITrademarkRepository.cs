using Core.DTO.Trademark;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Trademarks
{
    public interface ITrademarkRepository
    {
        //Lấy ds danh mục thương hiệu
        Task<IList<TrademarkItems>> GetAllTrademarksAsync(CancellationToken cancellationToken = default);

        //Lấy danh mục thương hiệu bằng id
        Task<Trademark> GetTrademarkByIdAsync(int id, CancellationToken cancellationToken = default);

        //Lấy danh mục thương hiệu bằng slug
        Task<Trademark> GetTrademarkBySlugAsync(string slug, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật danh mục thương hiệu
        Task<bool> AddOrUpdateTrademarkAsync(Trademark specificationCategory, CancellationToken cancellationToken = default);

        //Xóa danh mục thuộc tinh
        Task<bool> DeleteTrademarkAsync(int id, CancellationToken cancellationToken = default);

        //Kiểm tra slug
        Task<bool> IsTrademarkExistBySlugAsync(int id, string slug, CancellationToken cancellationToken = default);
    }
}
