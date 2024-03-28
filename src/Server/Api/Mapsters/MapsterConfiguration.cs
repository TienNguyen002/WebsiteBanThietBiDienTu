using Mapster;

namespace Api.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<Product, ProductDto>();

            //config.NewConfig<Color, ColorDto>();

            //config.NewConfig<Order, OrderDto>()
            //    .Map(desc => desc.Cart, src => src.Cart);

            //config.NewConfig<Tag, TagDto>();
        }
    }
}
