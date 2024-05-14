using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Product;
using Domain.DTO.Serie;
using Domain.Entities;
using Mapster;

namespace Api.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Branch, BranchProductDTO>();

            config.NewConfig<Serie, SerieDTO>();

            config.NewConfig<Product, ProductDTO>()
                .Map(desc => desc.Category, src => src.Serie.Category)
                .Map(desc => desc.Branch, src => src.Serie.Branch)
                .Map(desc => desc.Serie, src => src.Serie);

            config.NewConfig<Category, CategoryDTO>()
                .Map(dest => dest.ProductCount, src => src.Series.Sum(serie => serie.Products.Count));
        }
    }
}
