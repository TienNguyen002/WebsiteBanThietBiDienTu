using Domain.DTO.Comment;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly ISerieRepository _serieRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOtherRepository _otherRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(ICommentRepository repository, ISerieRepository serieRepository, IProductRepository productRepository, IOtherRepository otherRepository, UserManager<ApplicationUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _serieRepository = serieRepository;
            _productRepository = productRepository;
            _otherRepository = otherRepository;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddComment(CommentEditModel model)
        {
            var serie = await _serieRepository.GetSerieByProductSlug(model.ProductSlug);
            var product = await _productRepository.GetProductBySlug(model.ProductSlug);
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (serie == null || product == null || user == null)
            {
                return false;
            }
            var comment = new Comment()
            {
                Detail = model.Detail,
                Rating = model.Rating,
                SerieId = serie.Id,
                ApplicationUserId = user.Id,
                CommentDate = DateTime.Now,
            };
            var comments = await _repository.GetCommentsByProductSlug(model.ProductSlug);

            if (comments.Any())
            {
                var totalRating = comments.Sum(c => c.Rating) + model.Rating;
                var count = comments.Count + 1;
                serie.Rating = totalRating / (float)count;
            }
            else
            {
                serie.Rating = model.Rating;
            }
            var notification = new Notification()
            {
                Title = "New Comment",
                Description = user.Name + " vừa comment ở " + product.Name,
            };
            await _otherRepository.AddNofication(notification);
            await _productRepository.Update(product);
            await _repository.Add(comment);
            int saved = await _unitOfWork.Commit();
            return true;
        }

        public async Task<CommentCountDTO> CountAllComment(string slug)
        {
            return await _repository.CountAllComment(slug);
        }

        public async Task<IList<CommentDTO>> GetCommentsByProductSlug(string tag)
        {
            var comments = await _repository.GetCommentsByProductSlug(tag);
            return _mapper.Map<IList<CommentDTO>>(comments);
        }
    }
}
