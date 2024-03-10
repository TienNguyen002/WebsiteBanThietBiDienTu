using Core.DTO.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Apps.Statuses
{
    public interface IStatusRepository
    {
        //Lấy ds tình trạng
        Task<IList<StatusItems>> GetAllStatusAsync(CancellationToken cancellationToken = default);
    }
}
