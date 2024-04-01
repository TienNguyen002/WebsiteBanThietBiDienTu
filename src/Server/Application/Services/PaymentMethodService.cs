using Domain.DTO.PaymentMethod;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class PaymentMethodService : IPaymentMethodService 
    {
        private readonly IPaymentMethodRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentMethodService(IPaymentMethodRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add Payment Method
        /// </summary>
        /// <param name="model"> Model to add </param>
        /// <returns> Added Payment Method </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddPaymentMethod(PaymentMethodEditModel model)
        {
            var paymentMethod = new PaymentMethod()
            {
                Name = model.Name,
                Description = model.Description,
            };
            await _repository.AddPaymentMethod(paymentMethod);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Payment Method By Id
        /// </summary>
        /// <param name="id"> Id Of Payment Method want to delete </param>
        /// <returns> Deleted Payment Method </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeletePaymentMethod(int id)
        {
            await _repository.DeletePaymentMethod(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get All Payment Methods
        /// </summary>
        /// <returns> List Of Payment Methods </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<PaymentMethodDTO>> GetAllPaymentMethods()
        {
            var paymentMethods = await _repository.GetAll();
            return _mapper.Map<IList<PaymentMethodDTO>>(paymentMethods);
        }

        /// <summary>
        /// Get Payment Method By Id
        /// </summary>
        /// <param name="id"> Id Of Payment Method want to get </param>
        /// <returns> Get Payment Method By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<PaymentMethodDTO> GetPaymentMethodById(int id)
        {
            var paymentMethod = await _repository.GetById(id);
            return _mapper.Map<PaymentMethodDTO>(paymentMethod);
        }
    }
}
