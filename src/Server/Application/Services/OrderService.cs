using Domain.DTO.Order;
using Domain.DTO.Serie;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<OrderDTO>> GetAllOrders()
        {
            var orders = await _repository.GetAllOrders();
            return _mapper.Map<IList<OrderDTO>>(orders);
        }
    }
}
