using BusinessLayer;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Product;
using Mapster;
using WebMVC.Models.Category;
using WebMVC.Models.Manufacturer;
using WebMVC.Models.Product;

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

            TypeAdapterConfig<ManufacturerSummaryDTO, ManufacturerSummaryViewModel>.NewConfig()
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId);

            TypeAdapterConfig<CategorySummaryDTO, CategorySummaryViewModel>.NewConfig()
               .Map(dest => dest.CategoryId, src => src.CategoryId);
        }
    }
}
