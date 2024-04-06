using Domain.DTO.Status;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StatusService(IStatusRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All Statuses
        /// </summary>
        /// <returns> List Of Statuses </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<StatusDTO>> GetAllStatuses()
        {
            var statuses = await _repository.GetAll();
            return _mapper.Map<IList<StatusDTO>>(statuses);
        }
    }
}
