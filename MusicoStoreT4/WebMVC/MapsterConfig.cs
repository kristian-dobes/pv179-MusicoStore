using BusinessLayer;
using BusinessLayer.DTOs.Product;
using Mapster;
using WebMVC.Models.Product;
//using WebMVC.Models.Shared;

namespace WebMVC
{
    public class MapsterConfig : MappingConfig
    {
        public override void RegisterMappings()
        {
            base.RegisterMappings();

            TypeAdapterConfig<ProductCompleteDTO, ProductDetailViewModel>.NewConfig()
            .Map(dest => dest.Id, src => src.ProductId);
            TypeAdapterConfig<ProductCompleteDTO, ProductSummaryViewModel>.NewConfig()
            .Map(dest => dest.Id, src => src.ProductId);
        }
    }
}
