using BusinessLayer;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using Mapster;
using WebMVC.Models.Category;
using WebMVC.Models.Manufacturer;
using WebMVC.Models.Order;
using WebMVC.Models.Product;

namespace WebMVC
{
    public class MapsterConfig : MappingConfig
    {
        public override void RegisterMappings()
        {
            base.RegisterMappings();

            TypeAdapterConfig<ProductCompleteDTO, ProductDetailViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.ProductId)
                .Map(dest => dest.Manufacturer.ManufacturerId, src => src.ManufacturerId)
                .Map(dest => dest.Manufacturer.Name, src => src.ManufacturerName)
                .Map(dest => dest.Category.CategoryId, src => src.CategoryId)
                .Map(dest => dest.Category.Name, src => src.CategoryName);
            TypeAdapterConfig<ProductCompleteDTO, ProductSummaryViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.ProductId);

            TypeAdapterConfig<ManufacturerSummaryDTO, ManufacturerSummaryViewModel>
                .NewConfig()
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId);

            TypeAdapterConfig<CategorySummaryDTO, CategorySummaryViewModel>
                .NewConfig()
                .Map(dest => dest.CategoryId, src => src.CategoryId);

            TypeAdapterConfig<OrderDetailDto, OrderDetailViewModel>
                .NewConfig()
                .Map(dest => dest.OrderId, src => src.OrderId)
                .Map(dest => dest.PaymentStatus, src => src.PaymentStatus);

            TypeAdapterConfig<OrderItemCompleteDTO, OrderItemDto>
                .NewConfig()
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity);
            TypeAdapterConfig<OrderDetailDto, OrderUpdateViewModel>
                .NewConfig()
                .Map(dest => dest.Items, src => src.OrderItems.Adapt<IEnumerable<OrderItemDto>>()); // Map nested collection
            TypeAdapterConfig<OrderUpdateViewModel, UpdateOrderDto>
                .NewConfig()
                .Map(dest => dest.OrderItems, src => src.Items);

            TypeAdapterConfig<ProductDto, ProductDetailViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Manufacturer.Name, src => src.ManufacturerName)
                .Map(dest => dest.Category.Name, src => src.CategoryName);
        }
    }
}
