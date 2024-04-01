using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Discount;
using Domain.DTO.Product;
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

            //config.NewConfig<Branch, BranchDTO>();

        }
    }
}
