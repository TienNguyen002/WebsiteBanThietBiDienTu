using Domain.DTO.Comment;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(ICommentRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddComment(CommentEditModel model)
        {
            var comment = new Comment()
            {
                Detail = model.Detail,
                Rating = model.Rating,
                ProductId = model.ProductId,
                UserId = model.UserId,
                CommentDate = DateTime.Now,
            };
            _repository.Add(comment);
            int saved = await _unitOfWork.Commit();
            return true;
        }

        public async Task<IList<CommentDTO>> GetCommentsByProductTag(string tag)
        {
            var comments = await _repository.GetCommentsByProductTag(tag);
            return _mapper.Map<IList<CommentDTO>>(comments);
        }
    }
}
