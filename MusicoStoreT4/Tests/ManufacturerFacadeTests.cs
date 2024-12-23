using BusinessLayer.Facades;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Implementations.Implementations;
using Infrastructure.Repository.Implementations;
using Infrastructure.UnitOfWork;
using Moq;
using Tests.Other;

namespace Tests
{
    [TestFixture]
    public class ManufacturerFacadeTests
    {
        private ManufacturerFacade _manufacturerFacade;
        private IUnitOfWork _uow;

        [SetUp]
        public void SetUp()
        {
            var context = MockDbContext.GenerateMock();
            _uow = new UnitOfWork(context,
                                  new UserRepository(context),
                                  new CategoryRepository(context),
                                  new ManufacturerRepository(context),
                                  new OrderRepository(context),
                                  new OrderItemRepository(context),
                                  new ProductRepository(context),
                                  new ProductImageRepository(context),
                                  new AuditLogRepository(context),
                                  new LogRepository(context));
            _manufacturerFacade = new ManufacturerFacade(new ManufacturerService(_uow), new ProductService(_uow, new AuditLogService(_uow)));
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldThrowInvalidOperationException_WhenIdsAreSame()
        {
            // Arrange
            var manufacturerId = 1; // Using a valid manufacturer ID from the mock data

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _manufacturerFacade.MergeManufacturersAsync(manufacturerId, manufacturerId, -1));

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
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await _manufacturerFacade.MergeManufacturersAsync(manufacturerId20, manufacturerId1, -1));

            Assert.AreEqual($"Source manufacturer with ID {manufacturerId20} not found.", ex.Message);
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
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await _manufacturerFacade.MergeManufacturersAsync(sourceManufacturerId, targetManufacturerId, -1));

            Assert.AreEqual($"Target manufacturer with ID {targetManufacturerId} not found.", ex.Message);
        }

        [Test]
        public async Task MergeManufacturersAsync_ShouldCallReassignAndDelete_WhenBothExist()
        {
            // Arrange
            var manufacturerId1 = 1;
            var manufacturerId2 = 2;

            var manufacturer1 = await _uow.ManufacturersRep.GetByIdAsync(manufacturerId1);
            var manufacturer2 = await _uow.ManufacturersRep.GetByIdAsync(manufacturerId2);

            Assert.IsNotNull(manufacturer1, "Manufacturer 1 should exist.");
            Assert.IsNotNull(manufacturer2, "Manufacturer 2 should exist.");

            var productsOfMan1BeforeMerge = await _uow.ProductsRep.WhereAsync(p => p.ManufacturerId == manufacturerId1);
            var productsOfMan2BeforeMergeCount = (await _uow.ProductsRep.WhereAsync(p => p.ManufacturerId == manufacturerId2)).Count();
            Assert.IsNotEmpty(productsOfMan1BeforeMerge, "Manufacturer 1 should have products.");

            // Act
            await _manufacturerFacade.MergeManufacturersAsync(manufacturerId1, manufacturerId2, -1);

            // Assert
            var man2ProductsAfterMerge = await _uow.ProductsRep.WhereAsync(p => p.ManufacturerId == manufacturerId2);
            Assert.AreEqual(productsOfMan1BeforeMerge.Count() + productsOfMan2BeforeMergeCount, man2ProductsAfterMerge.Count(), "The number of reassigned products should match the original products of manufacturer 1.");
            Assert.IsTrue(man2ProductsAfterMerge.All(p => p.ManufacturerId == manufacturerId2), "All products should be reassigned to the target manufacturer.");

            var deletedManufacturer = await _uow.ManufacturersRep.GetByIdAsync(manufacturerId1);
            Assert.IsNull(deletedManufacturer, "The source manufacturer should be deleted.");
        }
    }
}