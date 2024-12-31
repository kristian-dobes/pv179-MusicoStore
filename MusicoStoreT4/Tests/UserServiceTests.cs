using BusinessLayer.Cache;
using BusinessLayer.Services;
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
                new LogRepository(context),
                new GiftCardRepository(context),
                new CouponCodeRepository(context)
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
            }
        }
    }
}
