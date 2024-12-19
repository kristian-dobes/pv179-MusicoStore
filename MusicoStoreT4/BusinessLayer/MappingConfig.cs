using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
using DataAccessLayer.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MappingConfig
    {
        public virtual void RegisterMappings()
        {
            RegisterEntityMaps();
            RegisterDTOMaps();
        }

        public void RegisterEntityMaps()
        {
            TypeAdapterConfig<ProductCompleteDTO, Product>.NewConfig()
                .Map(dest => dest.Id, src => src.ProductId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.QuantityInStock, src => src.QuantityInStock)
                .Map(dest => dest.LastModifiedBy, src => src.LastModifiedBy)
                .Map(dest => dest.EditCount, src => src.EditCount)
                .Map(dest => dest.OrderItems, src => src.OrderItems.Adapt<ICollection<OrderItem>>())
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId);
        }

        public void RegisterDTOMaps()
        {
            TypeAdapterConfig<Product, ProductCompleteDTO>.NewConfig()
                .Map(dest => dest.ProductId, src => src.Id)
                .Map(dest => dest.OrderItems, src => src.OrderItems.Adapt<ICollection<OrderItemCompleteDTO>>())
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId);
        }
    }
}
