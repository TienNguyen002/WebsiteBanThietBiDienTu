using Domain.DTO.Status;

namespace Domain.Interfaces.Services
{
    public interface IStatusService
    {
        Task<IList<StatusDTO>> GetAllStatuses();
    }
}
