using Domain.DTO.Other;
using Domain.DTO.Product;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Repositories;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Services
{
    public class OtherService : IOtherService
    {
        private readonly IOtherRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OtherService(IOtherRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddFeedback(FeedbackEditModel model)
        {
            var feedback = new Feedback()
            {
                Username = model.Username,
                Title = model.Title,
                Description = model.Description,
                CreatedDate = DateTime.Now,
            };
            await _repository.AddFeedback(feedback);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<ProductFilter> GetProductFiltersAsync()
        {
            return await _repository.GetProductFiltersAsync();
        }
    }
}
