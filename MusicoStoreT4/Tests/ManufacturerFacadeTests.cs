using BusinessLayer.Cache;
using BusinessLayer.Facades;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
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
    public class ManufacturerFacadeTests
    {
        private ManufacturerFacade _manufacturerFacade;
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
            _manufacturerFacade = new ManufacturerFacade(
                new ManufacturerService(
                    _uow,
                    new MemoryCacheWrapper(new MemoryCache(new MemoryCacheOptions()))
                ),
                new ProductService(_uow, new AuditLogService(_uow)),
                _uow
            );
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldThrowInvalidOperationException_WhenIdsAreSame()
        {
            // Arrange
            var manufacturerId = 1; // Using a valid manufacturer ID from the mock data

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(
                async () =>
                    await _manufacturerFacade.MergeManufacturersAsync(
                        manufacturerId,
                        manufacturerId,
                        -1
                    )
            );

            Assert.AreEqual("Source and target manufacturers must be different.", ex.Message);
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldThrowKeyNotFoundException_WhenSourceDoesNotExist()
        {
            // Arrange
            var manufacturerId20 = 20;
            var manufacturerId1 = 1;

            var manufacturer20 = await _uow.ManufacturersRep.GetByIdAsync(manufacturerId20);
            var manufacturer1 = await _uow.ManufacturersRep.GetByIdAsync(manufacturerId1);

            Assert.IsNull(manufacturer20, "Manufacturer with id 20 should not exist.");
            Assert.IsNotNull(manufacturer1, "Manufacturer with id 1 should exist.");

            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(
                async () =>
                    await _manufacturerFacade.MergeManufacturersAsync(
                        manufacturerId20,
                        manufacturerId1,
                        -1
                    )
            );

            Assert.AreEqual(
                $"Source manufacturer with ID {manufacturerId20} not found.",
                ex.Message
            );
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldThrowKeyNotFoundException_WhenTargetDoesNotExist()
        {
            // Arrange
            var sourceManufacturerId = 1;
            var targetManufacturerId = 20;

            var manufacturer1 = await _uow.ManufacturersRep.GetByIdAsync(sourceManufacturerId);
            var manufacturer20 = await _uow.ManufacturersRep.GetByIdAsync(targetManufacturerId);

            Assert.IsNotNull(manufacturer1, "Manufacturer with id 1 should exist.");
            Assert.IsNull(manufacturer20, "Manufacturer with id 20 should not exist.");

            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(
                async () =>
                    await _manufacturerFacade.MergeManufacturersAsync(
                        sourceManufacturerId,
                        targetManufacturerId,
                        -1
                    )
            );

            Assert.AreEqual(
                $"Target manufacturer with ID {targetManufacturerId} not found.",
                ex.Message
            );
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldCallReassignAndDelete_WhenBothExist()
        {
            // Arrange
            var manufacturerId1 = 1;
            var manufacturerId2 = 2;

            // Mock
            var manufacturer1 = new Manufacturer { Id = manufacturerId1, Name = "Manufacturer 1" };
            var manufacturer2 = new Manufacturer { Id = manufacturerId2, Name = "Manufacturer 2" };

            var productsOfMan1 = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    ManufacturerId = manufacturerId1
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    ManufacturerId = manufacturerId1
                }
            };

            var productsOfMan2 = new List<Product>
            {
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    ManufacturerId = manufacturerId2
                }
            };

            // ManufacturerService
            var mockManufacturerService = new Mock<IManufacturerService>();
            mockManufacturerService
                .Setup(m => m.ValidateManufacturerAsync(manufacturerId1))
                .ReturnsAsync(true);
            mockManufacturerService
                .Setup(m => m.ValidateManufacturerAsync(manufacturerId2))
                .ReturnsAsync(true);
            mockManufacturerService
                .Setup(m => m.DeleteManufacturerAsync(manufacturerId1))
                .ReturnsAsync(true);

            // ProductService
            var mockProductService = new Mock<IProductService>();
            mockProductService
                .Setup(p =>
                    p.ReassignProductsToManufacturerAsync(
                        manufacturerId1,
                        manufacturerId2,
                        It.IsAny<int>()
                    )
                )
                .Returns(Task.CompletedTask);

            // Act
            var manufacturerFacade = new ManufacturerFacade(
                mockManufacturerService.Object,
                mockProductService.Object,
                _uow
            );
            await manufacturerFacade.MergeManufacturersAsync(manufacturerId1, manufacturerId2, -1);

            // Assert
            mockManufacturerService.Verify(
                m => m.ValidateManufacturerAsync(manufacturerId1),
                Times.Once,
                "Source manufacturer validation should be called."
            );
            mockManufacturerService.Verify(
                m => m.ValidateManufacturerAsync(manufacturerId2),
                Times.Once,
                "Target manufacturer validation should be called."
            );
            mockProductService.Verify(
                p =>
                    p.ReassignProductsToManufacturerAsync(
                        manufacturerId1,
                        manufacturerId2,
                        It.IsAny<int>()
                    ),
                Times.Once,
                "Reassigning products should be called."
            );
            mockManufacturerService.Verify(
                m => m.DeleteManufacturerAsync(manufacturerId1),
                Times.Once,
                "Source manufacturer deletion should be called."
            );
        }
    }
}
