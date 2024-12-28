﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using DataAccessLayer.Models;
using Mapster;

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
            TypeAdapterConfig<ProductCompleteDTO, Product>
                .NewConfig()
                .Map(dest => dest.Id, src => src.ProductId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.QuantityInStock, src => src.QuantityInStock)
                .Map(dest => dest.LastModifiedById, src => src.LastModifiedById)
                .Map(dest => dest.EditCount, src => src.EditCount)
                .Map(dest => dest.PrimaryCategoryId, src => src.PrimaryCategoryId)
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId);
        }

        public void RegisterDTOMaps()
        {
            TypeAdapterConfig<Category, CategoryBasicDto>
                .NewConfig()
                .Map(dest => dest.CategoryId, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);

            TypeAdapterConfig<Product, ProductCompleteDTO>
                .NewConfig()
                .Map(dest => dest.ProductId, src => src.Id)
                .Map(dest => dest.PrimaryCategoryId, src => src.PrimaryCategoryId)
                .Map(dest => dest.PrimaryCategoryName, src => src.PrimaryCategory.Name)
                .Map(dest => dest.ManufacturerId, src => src.ManufacturerId)
                .Map(dest => dest.ManufacturerName, src => src.Manufacturer.Name)
                .Map(
                    dest => dest.SecondaryCategories,
                    src => src.SecondaryCategories.Adapt<IEnumerable<CategoryBasicDto>>()
                );

            TypeAdapterConfig<Manufacturer, ManufacturerSummaryDTO>
                .NewConfig()
                .Map(dest => dest.ManufacturerId, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(
                    dest => dest.ProductCount,
                    src => src.Products != null ? src.Products.Count() : 0
                );

            TypeAdapterConfig<Category, CategoryDTO>
                .NewConfig()
                .Map(dest => dest.CategoryId, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(
                    dest => dest.Products,
                    src => src.PrimaryProducts.Adapt<IEnumerable<ProductCompleteDTO>>()
                );
            TypeAdapterConfig<Category, CategorySummaryDTO>
                .NewConfig()
                .Map(dest => dest.CategoryId, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(
                    dest => dest.ProductCount,
                    src => src.PrimaryProducts != null ? src.PrimaryProducts.Count() : 0
                );

            TypeAdapterConfig<User, UserSummaryDTO>
                .NewConfig()
                .Map(dest => dest.UserId, src => src.Id)
                .Map(dest => dest.Username, src => src.Username)
                .Map(dest => dest.Email, src => src.Email)
                .Map(
                    dest => dest.NumberOfOrders,
                    src => src.Orders != null ? src.Orders.Count() : 0
                );

            TypeAdapterConfig<Customer, CustomerOrderDTO>
                .NewConfig()
                .Map(dest => dest.CustomerId, src => src.Id)
                .Map(dest => dest.Username, src => src.Username)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.City, src => src.City)
                .Map(dest => dest.State, src => src.State)
                .Map(dest => dest.PostalCode, src => src.PostalCode);
            TypeAdapterConfig<OrderItem, OrderItemCompleteDTO>
                .NewConfig()
                .Map(dest => dest.OrderItemId, src => src.Id)
                .Map(dest => dest.OrderId, src => src.OrderId)
                //.Map(dest => dest.Product, src => src.Product.Adapt<ProductCompleteDTO>())
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.ProductName, src => src.Product.Name)
                .Map(dest => dest.ProductDescription, src => src.Product.Description)
                .Map(dest => dest.ProductQuantityInStock, src => src.Product.QuantityInStock)
                .Map(dest => dest.CategoryId, src => src.Product.PrimaryCategoryId)
                .Map(dest => dest.CategoryName, src => src.Product.PrimaryCategory.Name)
                .Map(dest => dest.ManufacturerId, src => src.Product.ManufacturerId)
                .Map(dest => dest.ManufacturerName, src => src.Product.Manufacturer.Name)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.ProductPrice, src => src.Price)
                .Map(dest => dest.TotalPricePerOrderItem, src => src.Quantity * src.Price);

            TypeAdapterConfig<Order, OrderDetailDto>
                .NewConfig()
                .Map(dest => dest.OrderId, src => src.Id)
                .Map(dest => dest.Created, src => src.Date)
                .Map(
                    dest => dest.OrderItemsCount,
                    src => src.OrderItems != null ? src.OrderItems.Count() : 0
                )
                .Map(dest => dest.User, src => src.User.Adapt<CustomerOrderDTO>())
                .Map(
                    dest => dest.OrderItems,
                    src => src.OrderItems.Adapt<IEnumerable<OrderItemCompleteDTO>>()
                )
                .Map(
                    dest => dest.TotalOrderPrice,
                    src =>
                        src.OrderItems != null
                            ? src.OrderItems.Sum(oi => oi.Price * oi.Quantity)
                            : 0
                )
                .Map(dest => dest.OrderStatus, src => src.OrderStatus.ToString());
        }
    }
}
