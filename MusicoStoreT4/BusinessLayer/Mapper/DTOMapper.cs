using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public static class DTOMapper
    {
        private const int HighValueCustomerThreshold = 1000;
        private const int DaysOfInactivityThreshold = 180;
        public static UserSummaryDto MapToUserSummaryDto(this User user)
        {
            var totalExpenditure = user?.Orders?.Sum(o => o.OrderItems.Sum(oi => oi.Price * oi.Quantity)) ?? 0;

            return new UserSummaryDto
            {
                UserId = user.Id,
                Username = user.Username,
                Role = user.Role,
                TotalExpenditure = totalExpenditure
            };
        }

        public static OrderItemDto MapToOrderItemDto(this OrderItem orderItem)
        {
            return new OrderItemDto
            {
                ProductId = orderItem.ProductId ?? -1,
                Quantity = orderItem.Quantity
            };
        }

        public static CustomerSegmentsDto MapToCustomerSegmentsDto(
            this IEnumerable<Customer> customers,
            DateTime currentDate)
        {
            var highValueCustomers = customers
                .Where(c => c.Orders.Sum(o => o.OrderItems.Sum(oi => oi.Price * oi.Quantity)) > HighValueCustomerThreshold)
                .Select(c => c.MapToCustomerDto())
                .ToList();

            var infrequentCustomers = customers
                .Where(c => c.Orders.All(o => (currentDate - o.Date).Days > DaysOfInactivityThreshold))
                .Select(c => c.MapToCustomerDto())
                .ToList();

            return new CustomerSegmentsDto
            {
                HighValueCustomers = highValueCustomers,
                InfrequentCustomers = infrequentCustomers
            };
        }

        public static CustomerDto MapToCustomerDto(this Customer customer)
        {
            return new CustomerDto
            {
                Name = customer.Username,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                PostalCode = customer.PostalCode,
            };
        }
    }
}
