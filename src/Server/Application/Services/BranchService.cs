using Domain.DTO.Branch;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MapsterMapper;
using SlugGenerator;

namespace Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BranchService(IBranchRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add/Update By Find Branch Id, If Id > 0 Update it by Model, else Create New Branch By Model
        /// </summary>
        /// <param name="model"> Model to add/update </param>
        /// <returns> Added/Updated Branch </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddOrUpdateBranch(BranchEditModel model)
        {
            var branch = model.Id > 0 ? await _repository.GetById(model.Id) : null;
            if (branch == null)
            {
                branch = new Branch { };
            }
            branch.Name = model.Name;
            branch.UrlSlug = model.Name.GenerateSlug();
            await _repository.AddOrUpdate(branch);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Delete Branch By Id
        /// </summary>
        /// <param name="id"> Id Of Branch want to delete </param>
        /// <returns> Deleted Branch </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteBranch(int id)
        {
            await _repository.DeleteBranch(id);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        /// <summary>
        /// Get All Branches
        /// </summary>
        /// <returns> List Of Branches </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IList<BranchDTO>> GetAllBranches()
        {
            var branches = await _repository.GetAllWithInclude(b => b.Products);
            return _mapper.Map<IList<BranchDTO>>(branches);
        }

        /// <summary>
        /// Get Branch By Id
        /// </summary>
        /// <param name="id"> Id Of Branch want to get </param>
        /// <returns> Get Branch By Id </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<BranchDTO> GetBranchById(int id)
        {
            var branch = await _repository.GetByIdWithInclude(id, b => b.Products);
            return _mapper.Map<BranchDTO>(branch);
        }

        /// <summary>
        /// Get Branch By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Branch </param>
        /// <returns> Branch With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<BranchDTO> GetBranchBySlug(string slug)
        {
            var branch = await _repository.GetBranchBySlug(slug);
            return _mapper.Map<BranchDTO>(branch);
        }

        public async Task<IList<BranchProductDTO>> GetLimitBranchByCategory(int limit, string category)
        {
            var branches = await _repository.GetLimitBranchByCategory(limit, category);
            return _mapper.Map<IList<BranchProductDTO>>(branches);
        }
    }
}
