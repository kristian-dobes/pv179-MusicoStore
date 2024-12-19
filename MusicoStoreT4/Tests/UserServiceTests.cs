using BusinessLayer.DTOs;
using BusinessLayer.DTOs.User;
using BusinessLayer.Facades;
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

            // Make sure there is at least one order and order item for the user
            Assert.IsNotNull(user);
            Assert.IsNotEmpty(orders);
            Assert.IsNotEmpty(orderItems);

            // Act
            var result = await _userService.GetMostFrequentBoughtItemAsync(userId);

            // Assert
            Assert.IsNotNull(result);

            // Assuming the most frequent item is the one with the highest quantity
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

            // Retrieve the user and related orders from the context
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            var orderItems = _context.OrderItems.Where(oi => orders.Select(o => o.Id).Contains(oi.OrderId)).ToList();

            // Make sure there is at least one order and order item for the user
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

                // Assuming the most frequent item is the one with the highest quantity
                var mostFrequentOrderItem = orderItems
                    .GroupBy(oi => oi.ProductId)
                    .OrderByDescending(g => g.Sum(oi => oi.Quantity))
                    .FirstOrDefault();

                Assert.AreEqual(mostFrequentOrderItem.Key, result.ProductId);
                Assert.AreEqual(mostFrequentOrderItem.Sum(oi => oi.Quantity), result.Quantity);
            }
        }

        
        /*
        [Test]
        public void GetCustomerSegmentsAsync_ShouldReturnCustomerSegments()
        {
            // Arrange
            var customerSegmentsDto = new CustomerSegmentsDto();
            _userServiceMock.Setup(u => u.GetCustomerSegmentsAsync()).ReturnsAsync(customerSegmentsDto);

            // Act
            var result = _userServiceMock.Object.GetCustomerSegmentsAsync().Result;

            // Assert
            Assert.AreEqual(customerSegmentsDto, result);
        }
        [Test]
        public void GetCustomerSegmentsAsync_ShouldReturnNull_WhenNoCustomers()
        {
            // Arrange
            _userServiceMock.Setup(u => u.GetCustomerSegmentsAsync()).ReturnsAsync((CustomerSegmentsDto)null);

            // Act
            var result = _userServiceMock.Object.GetCustomerSegmentsAsync().Result;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetUserSummariesAsync_ShouldReturnUserSummaries()
        {
            // Arrange
            var userSummaries = new List<UserSummaryDto>();
            _userServiceMock.Setup(u => u.GetUserSummariesAsync()).ReturnsAsync(userSummaries);

            // Act
            var result = _userServiceMock.Object.GetUserSummariesAsync().Result;

            // Assert
            Assert.AreEqual(userSummaries, result);
        }

        [Test]
        public void GetUserSummariesAsync_ShouldHandleLargeDataset()
        {
            // Arrange
            var largeDataset = Enumerable.Range(1, 1000).Select(i => new UserSummaryDto { UserId = i }).ToList();
            _userServiceMock.Setup(u => u.GetUserSummariesAsync()).ReturnsAsync(largeDataset);

            // Act
            var result = _userServiceMock.Object.GetUserSummariesAsync().Result;

            // Assert
            Assert.AreEqual(1000, result.Count);
            CollectionAssert.AreEqual(largeDataset, result);
        }

        [Test]
        public void GetUserSummariesAsync_ShouldReturnNull_WhenDatasetIsEmpty()
        {
            // Arrange
            _userServiceMock.Setup(u => u.GetUserSummariesAsync()).ReturnsAsync((List<UserSummaryDto>)null);

            // Act
            var result = _userServiceMock.Object.GetUserSummariesAsync().Result;

            // Assert
            Assert.IsNull(result);
        }
        */
    }
}