using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User.Admin;
using BusinessLayer.DTOs.User.Customer;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;

namespace BusinessLayer.Mapper
{
    public static class EntityMapper
    {
        public static User MapToAdmin(this AdminDto adminDto)
        {
            return new User
            {
                Username = adminDto.Username,
                Email = adminDto.Email,
                Role = Role.Admin
            };
        }

        public static Customer MapToCustomer(this CustomerDto customerDto)
        {
            return new Customer
            {
                Username = customerDto.Username,
                Email = customerDto.Email,
                Role = Role.Customer,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address,
                City = customerDto.City,
                State = customerDto.State,
                PostalCode = customerDto.PostalCode
            };
        }

        public static Product MapToProduct(
            this ProductCreateDTO productDto,
            IEnumerable<Category> categories
        )
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                QuantityInStock = productDto.QuantityInStock,
                LastModifiedById = productDto.LastModifiedById,
                PrimaryCategoryId = productDto.PrimaryCategoryId,
                ManufacturerId = productDto.ManufacturerId,
                SecondaryCategories = categories
                    .Where(c => productDto.SecondaryCategoryIds.Contains(c.Id))
                    .ToList()
            };
        }
    }
}
