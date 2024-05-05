using Domain.DTO.Branch;
using Domain.DTO.Serie;
using Domain.Entities;
using Mapster;

namespace Api.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<Branch, BranchDTO>();

            //config.NewConfig<Category, CategoryDTO>();

            config.NewConfig<Branch, BranchProductDTO>();

            config.NewConfig<Serie, SerieDTO>()
                .Map(desc => desc.Category, src => src.Category.Name);
        }
    }
}
