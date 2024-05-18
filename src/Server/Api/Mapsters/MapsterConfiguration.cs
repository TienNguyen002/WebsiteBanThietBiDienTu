using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Order;
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
            config.NewConfig<Branch, BranchDTO>()
                .Map(desc => desc.ProductCount, src => src.Series.Sum(s => s.Products.Count));

            config.NewConfig<Serie, SeriesDTO>()
                .Map(desc => desc.Category, src => src.Category.Name)
                .Map(desc => desc.Branch, src => src.Branch.Name);

            config.NewConfig<Product, ProductDTO>()
                .Map(desc => desc.Category, src => src.Serie.Category)
                .Map(desc => desc.Branch, src => src.Serie.Branch)
                .Map(desc => desc.Serie, src => src.Serie);

            config.NewConfig<Category, CategoryDTO>()
                .Map(desc => desc.ProductCount, src => src.Series.Sum(s => s.Products.Count))
                .Map(desc => desc.Products, src => src.Series.Select(s => s.Products));

            config.NewConfig<Order, OrderDTO>()
                .Map(desc => desc.UserName, src => src.User.Name)
                .Map(desc => desc.Status, src => src.Status.Name)
                .Map(desc => desc.PaymentMethod, src => src.PaymentMethod.Name);
        }
    }
}
