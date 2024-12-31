using BusinessLayer;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.CouponCode;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using Mapster;
using WebMVC.Models.Category;
using WebMVC.Models.GiftCard;
using WebMVC.Models.Manufacturer;
using WebMVC.Models.Order;
using WebMVC.Models.Product;
using WebMVC.Models.User;

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
                .Map(dest => dest.PrimaryCategory.CategoryId, src => src.PrimaryCategoryId)
                .Map(dest => dest.PrimaryCategory.Name, src => src.PrimaryCategoryName)
                .Map(dest => dest.SecondaryCategories, src => src.SecondaryCategories)
                .Map(dest => dest.NumberOfSecondaryCategories, src => src.NumberOfSecondaryCategories)
                .Map(dest => dest.ImageFilePath, src => src.ImageFilePath);

            TypeAdapterConfig<ProductCompleteDTO, ProductSummaryViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.ProductId);

            TypeAdapterConfig<ProductCompleteDTO, ProductUpdateViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.ProductId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.QuantityInStock, src => src.QuantityInStock)
                .Map(dest => dest.PrimaryCategoryId, src => src.PrimaryCategoryId)
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId)
                .Map(dest => dest.SecondaryCategoryIds, src => src.SecondaryCategories.Select(c => c.CategoryId))
                .Map(dest => dest.ImagePath, src => src.ImageFilePath);

            TypeAdapterConfig<ProductDto, ProductDetailViewModel>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Manufacturer.Name, src => src.ManufacturerName)
                .Map(dest => dest.PrimaryCategory.Name, src => src.PrimaryCategoryName)
                .Map(
                    dest => dest.SecondaryCategories,
                    src => new List<CategoryBasicDto>(
                        src.SecondaryCategories.Select(c => new CategoryBasicDto { Name = c })
                    )
                );

            TypeAdapterConfig<ManufacturerSummaryDTO, ManufacturerSummaryViewModel>
                .NewConfig()
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId);

            TypeAdapterConfig<ManufacturerProductsDTO, ManufacturerProductsViewModel>
                .NewConfig()
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.ProductCount, src => src.ProductCount);

            TypeAdapterConfig<CategorySummaryDTO, CategorySummaryViewModel>
                .NewConfig()
                .Map(dest => dest.CategoryId, src => src.CategoryId);

            TypeAdapterConfig<CategoryProductsDTO, CategoryProductsViewModel>
                .NewConfig()
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.PrimaryProductCount, src => src.PrimaryProductCount)
                .Map(dest => dest.SecondaryProductCount, src => src.SecondaryProductCount);

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
                .Map(dest => dest.Items, src => src.OrderItems.Adapt<IEnumerable<OrderItemDto>>()) // Map nested collection
                .Map(dest => dest.PaymentStatus, src => src.PaymentStatus);

            TypeAdapterConfig<OrderSummaryDTO, OrderSummaryViewModel>
                .NewConfig()
                .Map(dest => dest.OrderId, src => src.OrderId)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.TotalOrderPrice, src => src.TotalOrderPrice)
                .Map(dest => dest.PaymentStatus, src => src.PaymentStatus);

            TypeAdapterConfig<OrderUpdateViewModel, UpdateOrderDto>
                .NewConfig()
                .Map(dest => dest.OrderItems, src => src.Items);

            TypeAdapterConfig<UserDto, UserSummaryViewModel>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Username, src => src.Username)
                .Map(dest => dest.Created, src => src.Created);

            TypeAdapterConfig<UserSummaryDTO, UserSummaryViewModel>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Username, src => src.Username);

            TypeAdapterConfig<CouponCodeDto, CouponCodeViewModel>
                .NewConfig()
                .Map(dest => dest.CouponCodeId, src => src.CouponCodeId)
                .Map(dest => dest.Created, src => src.Created)
                .Map(dest => dest.Code, src => src.Code)
                .Map(dest => dest.IsUsed, src => src.IsUsed)
                .Map(dest => dest.OrderId, src => src.OrderId);
        }
    }
}
