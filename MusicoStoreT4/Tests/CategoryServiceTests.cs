using BusinessLayer.DTOs;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Implementations.Implementations;
using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Other;
using BusinessLayer;
using Microsoft.AspNetCore.Identity;

namespace Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private IUnitOfWork _uow;
        private Mock<UserManager<LocalIdentityUser>> _mockUserManager;
        private CategoryService _service;

        [SetUp]
        public void SetUp()
        {
            var context = MockDbContext.GenerateMock();

            // Mock UserManager dependencies
            var store = new Mock<IUserStore<LocalIdentityUser>>();
            _mockUserManager = new Mock<UserManager<LocalIdentityUser>>(
                store.Object, null, null, null, null, null, null, null, null
            );

            _uow = new UnitOfWork(context,
                                  new UserRepository(context, _mockUserManager.Object),
                                  new CategoryRepository(context),
                                  new ManufacturerRepository(context),
                                  new OrderRepository(context),
                                  new OrderItemRepository(context),
                                  new ProductRepository(context),
                                  new ProductImageRepository(context),
                                  new AuditLogRepository(context),
                                  new LogRepository(context));
            _service = new CategoryService(_uow);
            
            // Mapster Mapping configuration for using DTOs
            new MappingConfig().RegisterMappings();
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnCategories()
        {
            // Act
            var result = await _service.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            await _uow.ProductsRep.DeleteByIdsAsync((await _uow.ProductsRep.GetAllAsync()).Select(p => p.Id));  // because of FK constraint
            await _uow.CategoriesRep.DeleteByIdsAsync((await _uow.CategoriesRep.GetAllAsync()).Select(c => c.Id));

            // Act
            var result = await _service.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnCategorySummary_WhenCategoryExists()
        {
            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual("Guitars", result.Name);
            Assert.AreEqual(2, result.ProductCount);
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange
            await _uow.ProductsRep.DeleteByIdsAsync((await _uow.ProductsRep.GetAllAsync()).Select(p => p.Id));
            await _uow.CategoriesRep.DeleteByIdsAsync((await _uow.CategoriesRep.GetAllAsync()).Select(c => c.Id));

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldThrowException_WhenOneSourceCategoryIsMissing()
        {
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _service.MergeCategoriesAndCreateNewAsync("New Category", 1, 20, false));

            Assert.AreEqual("One or both source categories not found.", ex.Message);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldReturnNewCategory_WhenSuccessful()
        {
            // Arrange
            var category1 = await _uow.CategoriesRep.GetByIdAsync(1);
            var category2 = await _uow.CategoriesRep.GetByIdAsync(2);
            Assert.IsNotNull(category1, "Category 1 is missing in the mock data.");
            Assert.IsNotNull(category2, "Category 2 is missing in the mock data.");

            var newCategoryName = "New Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            var savedCategory = (await _uow.CategoriesRep.WhereAsync(c => c.Name == newCategoryName)).FirstOrDefault();
            Assert.IsNotNull(savedCategory);
            Assert.AreEqual(newCategoryName, savedCategory.Name);

            var sourceCategories = (await _uow.CategoriesRep.WhereAsync(c => c.Id == 1 || c.Id == 2)).ToList();
            Assert.IsEmpty(sourceCategories);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldHandleEmptyProductLists()
        {
            // Arrange
            var category1 = await _uow.CategoriesRep.GetByIdAsync(1);
            var category2 = await _uow.CategoriesRep.GetByIdAsync(2);

            Assert.IsNotNull(category1, "Category 1 is missing in the mock data.");
            Assert.IsNotNull(category2, "Category 2 is missing in the mock data.");

            await _uow.ProductsRep.DeleteByIdsAsync((await _uow.ProductsRep.GetAllAsync()).Select(p => p.Id));

            var newCategoryName = "Merged Empty Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            var savedCategory = (await _uow.CategoriesRep.WhereAsync(c => c.Name == newCategoryName)).FirstOrDefault();
            Assert.IsNotNull(savedCategory);

            var sourceCategories = (await _uow.CategoriesRep.WhereAsync(c => c.Id == 1 || c.Id == 2)).ToList();
            Assert.IsEmpty(sourceCategories);

            var productsForNewCategory = (await _uow.ProductsRep.WhereAsync(p => p.CategoryId == savedCategory.Id)).ToList();
            Assert.IsEmpty(productsForNewCategory, "The new category should have no associated products.");
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldProperlyAssignProductsToNewCategory()
        {
            // Arrange
            var category1 = await _uow.CategoriesRep.GetByIdAsync(1);
            var category2 = await _uow.CategoriesRep.GetByIdAsync(2);
            Assert.IsNotNull(category1, "Category 1 is missing in the mock data.");
            Assert.IsNotNull(category2, "Category 2 is missing in the mock data.");

            var product1 = (await _uow.ProductsRep.WhereAsync(p => p.Id == 1)).FirstOrDefault();
            var product2 = (await _uow.ProductsRep.WhereAsync(p => p.Id == 2)).FirstOrDefault();
            Assert.IsNotNull(product1, "Product 1 is missing in the mock data.");
            Assert.IsNotNull(product2, "Product 2 is missing in the mock data.");

            product1.CategoryId = category1.Id;
            product2.CategoryId = category2.Id;

            await _uow.SaveAsync();

            var newCategoryName = "Merged Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            var savedCategory = (await _uow.CategoriesRep.WhereAsync(c => c.Name == newCategoryName)).FirstOrDefault();
            Assert.IsNotNull(savedCategory);

            var reassignedProducts = (await _uow.ProductsRep.WhereAsync(p => p.CategoryId == savedCategory.Id)).ToList();
            Assert.AreEqual(3, reassignedProducts.Count);
            Assert.Contains(product1, reassignedProducts);
            Assert.Contains(product2, reassignedProducts);

            var sourceCategories = (await _uow.CategoriesRep.WhereAsync(c => c.Id == 1 || c.Id == 2)).ToList();
            Assert.IsEmpty(sourceCategories, "Source categories should be removed after merging.");
        }
    }
}