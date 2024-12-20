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
    public class ManufacturerFacadeTests
    {
        private MyDBContext _context;
        private ManufacturerFacade _manufacturerFacade;
        private ProductService _productService;
        private ManufacturerService _manufacturerService;

        [SetUp]
        public void SetUp()
        {
            _context = MockDbContext.GenerateMock();

            _productService = new ProductService(_context, new AuditLogService(_context));
            _manufacturerService = new ManufacturerService(_context);
            _manufacturerFacade = new ManufacturerFacade(_manufacturerService, _productService);
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

            var manufacturer20 = _context.Manufacturers.SingleOrDefault(c => c.Id == manufacturerId20);
            var manufacturer1 = _context.Manufacturers.SingleOrDefault(c => c.Id == manufacturerId1);

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

            var manufacturer1 = _context.Manufacturers.SingleOrDefault(c => c.Id == sourceManufacturerId);
            var manufacturer20 = _context.Manufacturers.SingleOrDefault(c => c.Id == targetManufacturerId);

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

            var manufacturer1 = _context.Manufacturers.SingleOrDefault(m => m.Id == manufacturerId1);
            var manufacturer2 = _context.Manufacturers.SingleOrDefault(m => m.Id == manufacturerId2);

            Assert.IsNotNull(manufacturer1, "Manufacturer 1 should exist.");
            Assert.IsNotNull(manufacturer2, "Manufacturer 2 should exist.");

            var productsOfMan1BeforeMerge = _context.Products.Where(p => p.ManufacturerId == manufacturerId1).ToList();
            var productsOfMan2BeforeMergeCount = _context.Products.Where(p => p.ManufacturerId == manufacturerId2).Count();
            Assert.IsNotEmpty(productsOfMan1BeforeMerge, "Manufacturer 1 should have products.");

            // Act
            await _manufacturerFacade.MergeManufacturersAsync(manufacturerId1, manufacturerId2, -1);

            // Assert
            var man2ProductsAfterMerge = _context.Products.Where(p => p.ManufacturerId == manufacturerId2).ToList();
            Assert.AreEqual(productsOfMan1BeforeMerge.Count + productsOfMan2BeforeMergeCount, man2ProductsAfterMerge.Count, "The number of reassigned products should match the original products of manufacturer 1.");
            Assert.IsTrue(man2ProductsAfterMerge.All(p => p.ManufacturerId == manufacturerId2), "All products should be reassigned to the target manufacturer.");

            var deletedManufacturer = _context.Manufacturers.SingleOrDefault(m => m.Id == manufacturerId1);
            Assert.IsNull(deletedManufacturer, "The source manufacturer should be deleted.");
        }
    }
}