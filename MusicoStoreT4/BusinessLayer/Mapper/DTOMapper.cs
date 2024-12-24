using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using BusinessLayer.DTOs.User.Customer;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;

namespace BusinessLayer.Mapper
{
    public static class DTOMapper
    {
        public static bool IsAdmin(this User user)
        {
            return user.Role == Role.Admin;
        }

        public static UserDto MapToUserDto(this User user)
        {
            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
                Created = user.Created,
                CustomerDetails = user.MapToCustomerDetailsDto()
            };
        }
        public static CustomerDetailsDto MapToCustomerDetailsDto(this Customer customer)
        {
            return new CustomerDetailsDto
            {
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode
            };
        }

        private static CustomerDetailsDto? MapToCustomerDetailsDto(this User user)
        {
            return user.IsAdmin() ? null : (user as Customer).MapToCustomerDetailsDto();
        }

        public static UserDetailDto MapToUserDetailDto(this User user)
        {
            return new UserDetailDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
                Created = user.Created,
                CustomerDetails = user.MapToCustomerDetailsDto(),
                Orders = user.Orders?.Select(o => o.MapToOrderDto())
            };
        }

        public static OrderDto MapToOrderDto(this Order order)
        {
            return new OrderDto
            {
                OrderId = order.Id,
                OrderDate = order.Date,
                Created = order.Created
            };
        }

        public static CustomerDto MapToCustomerDto(this Customer customer)
        {
            return new CustomerDto
            {
                Username = customer.Username,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode,
            };
        }

        public static ProductDto MapToProductDTO(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category?.Name ?? "",
                ManufacturerName = product.Manufacturer?.Name ?? "",
                QuantityInStock = product.QuantityInStock,
                DateCreated = product.Created
            };
        }
    }
}
