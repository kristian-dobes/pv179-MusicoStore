using BusinessLayer.Cache;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.User;
using BusinessLayer.DTOs.User.Customer;
using BusinessLayer.Facades;
using BusinessLayer.Mapper;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Implementations.Implementations;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Tests.Other;

namespace Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private UserService _userService;
        private Mock<UserManager<LocalIdentityUser>> _mockUserManager;
        private IUnitOfWork _uow;

        [SetUp]
        public void SetUp()
        {
            var context = MockDbContext.GenerateMock();

            // Mock UserManager dependencies
            var store = new Mock<IUserStore<LocalIdentityUser>>();
            _mockUserManager = new Mock<UserManager<LocalIdentityUser>>(
                store.Object,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );

            _uow = new UnitOfWork(
                context,
                new UserRepository(context, _mockUserManager.Object),
                new CategoryRepository(context),
                new ManufacturerRepository(context),
                new OrderRepository(context),
                new OrderItemRepository(context),
                new ProductRepository(context),
                new ProductImageRepository(context),
                new AuditLogRepository(context),
                new LogRepository(context)
            );
            _userService = new UserService(
                _uow,
                new MemoryCacheWrapper(new MemoryCache(new MemoryCacheOptions()))
            );
        }

        [Test]
        public async Task GetMostFrequentBoughtItemAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            int userId = 1;
            await _uow.UsersRep.DeleteByIdsAsync(
                (await _uow.UsersRep.GetAllAsync()).Select(u => u.Id)
            );

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
            await _uow.OrdersRep.DeleteByIdsAsync(
                (await _uow.OrdersRep.GetAllAsync()).Select(o => o.Id)
            );
            await _uow.OrderItemsRep.DeleteByIdsAsync(
                (await _uow.OrderItemsRep.GetAllAsync()).Select(oi => oi.Id)
            );

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

            var user = await _uow.UsersRep.GetByIdAsync(userId);
            var orders = await _uow.OrdersRep.WhereAsync(o => o.UserId == userId);
            var orderItems = await _uow.OrderItemsRep.WhereAsync(oi =>
                orders.Select(o => o.Id).Contains(oi.OrderId)
            );

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

            // Retrieve the user and related orders from the unit of work
            var user = await _uow.UsersRep.GetByIdAsync(userId);
            var orders = await _uow.OrdersRep.WhereAsync(o => o.UserId == userId);
            var orderItems = await _uow.OrderItemsRep.WhereAsync(oi =>
                orders.Select(o => o.Id).Contains(oi.OrderId)
            );

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

            var user = await _uow.UsersRep.GetByIdAsync(userId);
            var orders = await _uow.OrdersRep.WhereAsync(o => o.UserId == userId);
            var orderItems = await _uow.OrderItemsRep.WhereAsync(oi =>
                orders.Select(o => o.Id).Contains(oi.OrderId)
            );

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
            var customer1 = (Customer?)(await _uow.UsersRep.GetByIdAsync(3));
            var customer2 = (Customer?)(await _uow.UsersRep.GetByIdAsync(4));

            var customerSegmentsDto = new CustomerSegmentsDto()
            {
                HighValueCustomers = new List<CustomerDto>()
                {
                    customer1.MapToCustomerDto(),
                    customer2.MapToCustomerDto()
                },
                InfrequentCustomers = new List<CustomerDto>()
            };

            // Act
            var result = await _userService.GetCustomerSegmentsAsync();

            // Assert
            CollectionAssert.AreEquivalent(
                customerSegmentsDto.HighValueCustomers,
                result.HighValueCustomers
            );
            CollectionAssert.AreEquivalent(
                customerSegmentsDto.InfrequentCustomers,
                result.InfrequentCustomers
            );
        }

        [Test]
        public async Task GetCustomerSegmentsAsync_ShouldReturnEmptyLists_WhenNoCustomers()
        {
            // Arrange
            var customers = await _uow.UsersRep.GetAllAsync();
            await _uow.UsersRep.DeleteByIdsAsync(customers.Select(c => c.Id));
            await _uow.SaveAsync();

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
            var userIds = (await _uow.UsersRep.GetAllAsync()).Select(u => u.Id);
            var customerIds = (await _uow.UsersRep.GetAllAsync()).Select(c => c.Id);

            await _uow.UsersRep.DeleteByIdsAsync(userIds);
            await _uow.UsersRep.DeleteByIdsAsync(customerIds);
            await _uow.SaveAsync();

            // Act
            var result = await _userService.GetAllUserSummariesAsync();

            // Assert
            Assert.IsEmpty(result);
        }
    }
}
