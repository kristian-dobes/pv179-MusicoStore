using BusinessLayer.DTOs;
using BusinessLayer.DTOs.User;
using BusinessLayer.Facades;
using BusinessLayer.Mapper;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Moq;
using Tests.Other;

namespace Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private MyDBContext _context;
        private UserService _userService;
        private ProductService _productService;

        [SetUp]
        public void SetUp()
        {
            _context = MockDbContext.GenerateMock();
            _userService = new UserService(_context);
            _productService = new ProductService(_context);
        }

        [Test]
        public async Task GetMostFrequentBoughtItemAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            int userId = 1;
            _context.Users.RemoveRange(_context.Users.ToList());
            await _context.SaveChangesAsync();

            // Act
            var result = await _userService.GetMostFrequentBoughtItemAsync(userId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetMostFrequentBoughtItemAsync_ShouldReturnNull_WhenUserHasNoOrders()
        {
            // Arrange
            int userId = 1;
            _context.Orders.RemoveRange(_context.Orders.ToList());
            _context.OrderItems.RemoveRange(_context.OrderItems.ToList());
            await _context.SaveChangesAsync();

            // Act
            var result = await _userService.GetMostFrequentBoughtItemAsync(userId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetMostFrequentBoughtItemAsync_ShouldReturnMostFrequentItem_WhenUserHasOrders()
        {
            // Arrange
            int userId = 1;

            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            var orderItems = _context.OrderItems.Where(oi => orders.Select(o => o.Id).Contains(oi.OrderId)).ToList();

            Assert.IsNotNull(user);
            Assert.IsNotEmpty(orders);
            Assert.IsNotEmpty(orderItems);

            // Act
            var result = await _userService.GetMostFrequentBoughtItemAsync(userId);

            // Assert
            Assert.IsNotNull(result);

            var mostFrequentOrderItem = orderItems
                .GroupBy(oi => oi.ProductId)
                .OrderByDescending(g => g.Sum(oi => oi.Quantity))
                .FirstOrDefault();

            Assert.AreEqual(mostFrequentOrderItem.Key, result.ProductId);
            Assert.AreEqual(mostFrequentOrderItem.Sum(oi => oi.Quantity), result.Quantity);
        }

        [Test]
        public async Task GetMostFrequentBoughtItemAsync_ShouldReturnNotNull_WhenUserHasOrders()
        {
            // Arrange
            int userId = 1;

            // Retrieve the user and related orders from the context
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            var orderItems = _context.OrderItems.Where(oi => orders.Select(o => o.Id).Contains(oi.OrderId)).ToList();

            Assert.IsNotNull(user);
            Assert.IsNotEmpty(orders);
            Assert.IsNotEmpty(orderItems);

            // Act
            var result = await _userService.GetMostFrequentBoughtItemAsync(userId);

            // Assert
            Assert.IsNotNull(result);

            var mostFrequentOrderItem = orderItems
                .GroupBy(oi => oi.ProductId)
                .OrderByDescending(g => g.Sum(oi => oi.Quantity))
                .FirstOrDefault();

            Assert.AreEqual(mostFrequentOrderItem.Key, result.ProductId);
            Assert.AreEqual(mostFrequentOrderItem.Sum(oi => oi.Quantity), result.Quantity);
        }

        [Test]
        public async Task GetMostFrequentBoughtItemAsync_ShouldHandleMultipleConcurrentRequests()
        {
            // Arrange
            int userId = 1;

            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            var orderItems = _context.OrderItems.Where(oi => orders.Select(o => o.Id).Contains(oi.OrderId)).ToList();

            Assert.IsNotNull(user);
            Assert.IsNotEmpty(orders);
            Assert.IsNotEmpty(orderItems);

            // Act
            var tasks = new[]
            {
                _userService.GetMostFrequentBoughtItemAsync(userId),
                _userService.GetMostFrequentBoughtItemAsync(userId),
                _userService.GetMostFrequentBoughtItemAsync(userId)
            };

            var results = await Task.WhenAll(tasks);

            // Assert
            foreach (var result in results)
            {
                Assert.IsNotNull(result);

                var mostFrequentOrderItem = orderItems
                    .GroupBy(oi => oi.ProductId)
                    .OrderByDescending(g => g.Sum(oi => oi.Quantity))
                    .FirstOrDefault();

                Assert.AreEqual(mostFrequentOrderItem.Key, result.ProductId);
                Assert.AreEqual(mostFrequentOrderItem.Sum(oi => oi.Quantity), result.Quantity);
            }
        }

        [Test]
        public async Task GetCustomerSegmentsAsync_ShouldReturnCustomerSegments()
        {
            // Arrange
            var customerSegmentsDto = new CustomerSegmentsDto()
            {
                HighValueCustomers = new List<CustomerDto>() { _context.Customers.FirstOrDefault(u => u.Id == 3).MapToCustomerDto(),
                                                               _context.Customers.FirstOrDefault(u => u.Id == 4).MapToCustomerDto() },
                InfrequentCustomers = new List<CustomerDto>()
            };

            // Act
            var result = await _userService.GetCustomerSegmentsAsync();

            // Assert
            CollectionAssert.AreEquivalent(customerSegmentsDto.HighValueCustomers, result.HighValueCustomers);
            CollectionAssert.AreEquivalent(customerSegmentsDto.InfrequentCustomers, result.InfrequentCustomers);
        }

        
        [Test]
        public async Task GetCustomerSegmentsAsync_ShouldReturnEmptyLists_WhenNoCustomers()
        {
            // Arrange
            _context.Customers.RemoveRange(_context.Customers.ToList());
            await _context.SaveChangesAsync();

            // Act
            var result = await _userService.GetCustomerSegmentsAsync();

            // Assert
            Assert.IsEmpty(result.HighValueCustomers);
            Assert.IsEmpty(result.InfrequentCustomers);
        }

        [Test]
        public async Task GetUserSummariesAsync_ShouldReturnEmpty_WhenDatasetIsEmpty()
        {
            // Arrange
            _context.Users.RemoveRange(_context.Users.ToList());
            _context.Customers.RemoveRange(_context.Customers.ToList());
            await _context.SaveChangesAsync();

            // Act
            var result = await _userService.GetUserSummariesAsync();

            // Assert
            Assert.IsEmpty(result);
        }
    }
}