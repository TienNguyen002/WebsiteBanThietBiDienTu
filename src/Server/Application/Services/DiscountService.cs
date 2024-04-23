using Domain.DTO.Discount;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DiscountService(IDiscountRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add Discount
        /// </summary>
        /// <param name="model"> Model to add </param>
        /// <returns> Added Discount </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddDiscount(DiscountEditModel model)
        {
            var discount = new Discount()
            {
                StartDate = DateTime.Now,
                EndDate = model.EndDate,
                Status = true,
            };
            await _repository.Add(discount);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Discount By Id
        /// </summary>
        /// <param name="id"> Id Of Discount want to delete </param>
        /// <returns> Deleted Discount </returns>
        /// <exception cref="Exception"></exception>
        //public async Task<bool> DeleteDiscount(int id)
        //{
        //    await _repository.DeleteDiscount(id);
        //    int saved = await _unitOfWork.Commit();
        //    return saved > 0;
        //}

        /// <summary>
        /// Get All Discounts
        /// </summary>
        /// <returns> List Of Discounts </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<DiscountDTO>> GetAllDiscounts()
        {
            var discounts = await _repository.GetAll();
            return _mapper.Map<IList<DiscountDTO>>(discounts);
        }

        /// <summary>
        /// Get Discount By Id
        /// </summary>
        /// <param name="id"> Id Of Discount want to get </param>
        /// <returns> Get Discount By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DiscountDTO> GetDiscountById(int id)
        {
            var discount = await _repository.GetById(id);
            return _mapper.Map<DiscountDTO>(discount);
        }
    }
}
