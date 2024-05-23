using Application.Media;
using Domain.DTO.Image;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediaManager _mediaManager;
        private readonly IUnitOfWork _unitOfWork;   
        public ImageService(IImageRepository repository, IMapper mapper, IMediaManager mediaManager, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _mediaManager = mediaManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddOrUpdateImage(ImageEditModel model)
        {
            var image = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (image == null)
            {
                image = new Image();
            }
            image.ImageUrl = await _mediaManager.SaveImgFileAsync(model.ImageFile.OpenReadStream(),
                                                                    model.ImageFile.FileName,
                                                                    model.ImageFile.ContentType);
            await _repository.AddOrUpdate(image);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<bool> DeleteImage(int id)
        {
            await _repository.DeleteImage(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<IList<ImageDTO>> GetAllImages()
        {
            var images = await _repository.GetAll();
            return _mapper.Map<IList<ImageDTO>>(images);
        }

        public async Task<ImageDTO> GetImageById(int id)
        {
            var image = await _repository.GetById(id);
            return _mapper.Map<ImageDTO>(image);
        }
    }
}
