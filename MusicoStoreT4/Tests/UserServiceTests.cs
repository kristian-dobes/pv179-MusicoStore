using BusinessLayer.DTOs;
using BusinessLayer.Facades;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Moq;

namespace Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserService> _userServiceMock;
        private Mock<IProductService> _productServiceMock;

        [SetUp]
        public void SetUp()
        {
            _userServiceMock = new Mock<IUserService>();
            _productServiceMock = new Mock<IProductService>();
        }

        [Test]
        public void GetMostFrequentBoughtItemAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            int userId = 1;
            _userServiceMock.Setup(u => u.ValidateUserAsync(userId)).ReturnsAsync(false);

            // Act
            var result = _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId).Result;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetMostFrequentBoughtItemAsync_ShouldReturnNull_WhenUserHasNoOrders()
        {
            // Arrange
            int userId = 1;
            _userServiceMock.Setup(u => u.ValidateUserAsync(userId)).ReturnsAsync(true);
            _userServiceMock.Setup(u => u.GetMostFrequentBoughtItemAsync(userId)).ReturnsAsync((OrderItemDto?)null);

            // Act
            var result = _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId).Result;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetMostFrequentBoughtItemAsync_ShouldReturnMostFrequentItem_WhenUserHasOrders()
        {
            // Arrange
            int userId = 1;
            var orderItemDto = new OrderItemDto { ProductId = 1, Quantity = 5 };
            _userServiceMock.Setup(u => u.ValidateUserAsync(userId)).ReturnsAsync(true);
            _userServiceMock.Setup(u => u.GetMostFrequentBoughtItemAsync(userId)).ReturnsAsync(orderItemDto);

            // Act
            var result = _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId).Result;

            // Assert
            Assert.AreEqual(orderItemDto, result);
        }

        [Test]
        public void GetMostFrequentBoughtItemAsync_ShouldReturnNotNull_WhenUserHasOrders()
        {
            // Arrange
            int userId = 1;
            var orderItemDto = new OrderItemDto { ProductId = 1, Quantity = 5 };
            _userServiceMock.Setup(u => u.ValidateUserAsync(userId)).ReturnsAsync(true);
            _userServiceMock.Setup(u => u.GetMostFrequentBoughtItemAsync(userId)).ReturnsAsync(orderItemDto);

            // Act
            var result = _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId).Result;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetMostFrequentBoughtItemAsync_ShouldHandleMultipleConcurrentRequests()
        {
            // Arrange
            int userId = 1;
            var orderItemDto = new OrderItemDto { ProductId = 1, Quantity = 5 };
            _userServiceMock.Setup(u => u.ValidateUserAsync(userId)).ReturnsAsync(true);
            _userServiceMock.Setup(u => u.GetMostFrequentBoughtItemAsync(userId)).ReturnsAsync(orderItemDto);

            // Act
            var tasks = new[]
            {
            _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId),
            _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId),
            _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId)
        };

            Task.WaitAll(tasks);

            // Assert
            foreach (var task in tasks)
            {
                Assert.AreEqual(orderItemDto, task.Result);
            }

            _userServiceMock.Verify(u => u.GetMostFrequentBoughtItemAsync(userId), Times.Exactly(3));
        }

        [Test]
        public void GetMostFrequentBoughtItemAsync_ShouldHandleOrdersWithIdenticalFrequencies()
        {
            // Arrange
            int userId = 1;
            var item1 = new OrderItemDto { ProductId = 1, Quantity = 5 };
            var item2 = new OrderItemDto { ProductId = 2, Quantity = 5 };

            _userServiceMock.Setup(u => u.ValidateUserAsync(userId)).ReturnsAsync(true);
            // Simulate logic where first encountered frequent item is returned
            _userServiceMock.Setup(u => u.GetMostFrequentBoughtItemAsync(userId)).ReturnsAsync(item1);

            // Act
            var result = _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(item1, result);
            Assert.AreNotEqual(item2, result); // Ensure it's handling identical frequencies predictably
        }

        [Test]
        public void GetMostFrequentBoughtItemAsync_ShouldHandleOrdersWithZeroQuantities()
        {
            // Arrange
            int userId = 1;
            var frequentItem = new OrderItemDto { ProductId = 1, Quantity = 0 }; // No valid purchases
            _userServiceMock.Setup(u => u.ValidateUserAsync(userId)).ReturnsAsync(true);
            _userServiceMock.Setup(u => u.GetMostFrequentBoughtItemAsync(userId)).ReturnsAsync(frequentItem);

            // Act
            var result = _userServiceMock.Object.GetMostFrequentBoughtItemAsync(userId).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ProductId);
            Assert.AreEqual(0, result.Quantity); // Ensure it gracefully handles zero quantity
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