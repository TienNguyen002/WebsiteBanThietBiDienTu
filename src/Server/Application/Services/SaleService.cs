using Domain.DTO.Sale;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SaleService(ISaleRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get Sale By Id
        /// </summary>
        /// <param name="id"> Id Of Sale want to get </param>
        /// <returns> Get Sale By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<SaleDTO> GetSaleById(int id)
        {
            var sale = await _repository.GetByIdWithInclude(id, b => b.Products);
            return _mapper.Map<SaleDTO>(sale);
        }

        /// <summary>
        /// Get Current Sale By Id
        /// </summary>
        /// <param name="id"> Id Of Sale want to get </param>
        /// <returns> Current Sale Products </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<SaleDTO> GetCurrentSale(int id)
        {
            var sale = await _repository.GetCurrentSale(id);
            return _mapper.Map<SaleDTO>(sale);
        }
    }
}
