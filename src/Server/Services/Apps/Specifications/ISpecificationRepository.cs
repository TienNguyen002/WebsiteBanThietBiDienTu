using Core.DTO.Specification;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Specifications
{
    public interface ISpecificationRepository
    {
        //Lấy ds thuộc tính
        Task<IList<SpecificationItems>> GetAllSpecificationsAsync(CancellationToken cancellationToken = default);

        //Lấy thuộc tính bằng id
        Task<Specification> GetSpecificationByIdAsync(int id, CancellationToken cancellationToken = default);

        //Thêm/Cập nhật thuộc tính
        Task<bool> AddOrUpdateSpecificationAsync(Specification specification, CancellationToken cancellationToken = default);

        //Xóa thuộc tính
        Task<bool> DeleteSpecificationAsync(int id, CancellationToken cancellationToken = default);
    }
}
