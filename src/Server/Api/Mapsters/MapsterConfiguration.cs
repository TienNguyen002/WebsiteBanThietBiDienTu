using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Comment;
using Domain.DTO.Discount;
using Domain.DTO.Order;
using Domain.DTO.OrderItem;
using Domain.DTO.Product;
using Domain.DTO.Serie;
using Domain.DTO.User;
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

            config.NewConfig<Discount, DiscountDTO>()
                .Map(desc => desc.DiscountPrice, src => src.DiscountPercent);

            config.NewConfig<Product, ProductDTO>()
                .Map(desc => desc.Rating, src => src.Serie.Rating)
                .Map(desc => desc.Category, src => src.Serie.Category)
                .Map(desc => desc.Branch, src => src.Serie.Branch)
                .Map(desc => desc.Serie, src => src.Serie);

            config.NewConfig<Product, ProductByCategoryDTO>()
                .Map(desc => desc.Rating, src => src.Serie.Rating);

            config.NewConfig<Category, CategoryDTO>()
                .Map(desc => desc.ProductCount, src => src.Series.Sum(s => s.Products.Count))
                .Map(desc => desc.Products, src => src.Series.Select(s => s.Products));

            config.NewConfig<Comment, CommentDTO>()
                .Map(desc => desc.Username, src => src.ApplicationUser.Name);

            config.NewConfig<Order, OrderDTO>()
                .Map(desc => desc.UserName, src => src.ApplicationUser.Name)
                .Map(desc => desc.Status, src => src.Status.Name)
                .Map(desc => desc.PaymentMethod, src => src.PaymentMethod.Name);

            config.NewConfig<OrderItem, OrderItemsDTO>()
                .Map(desc => desc.ImageUrl, src => src.Product.ImageUrl)
                .Map(desc => desc.ProductName, src => src.Product.Name);

            config.NewConfig<ApplicationUser, UserDTO>()
                .Map(desc => desc.Id, src => src.Id)
                .Map(desc => desc.Name, src => src.Name)
                .Map(desc => desc.Email, src => src.Email)
                .Map(desc => desc.Address, src => src.Address)
                .Map(desc => desc.PhoneNumber, src => src.PhoneNumber);
        }
    }
}
