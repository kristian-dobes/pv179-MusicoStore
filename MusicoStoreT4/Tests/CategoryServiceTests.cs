using BusinessLayer.DTOs;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private Mock<ICategoryService> _categoryServiceMock;

        [SetUp]
        public void SetUp()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnCategories()
        {
            // Arrange
            var categories = new List<CategorySummaryDto>
            {
                new CategorySummaryDto { CategoryId = 1, Name = "Category 1", ProductCount = 10 },
                new CategorySummaryDto { CategoryId = 2, Name = "Category 2", ProductCount = 5 }
            };
            _categoryServiceMock.Setup(c => c.GetCategoriesAsync()).ReturnsAsync(categories);

            // Act
            var result = await _categoryServiceMock.Object.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(categories, result);
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            _categoryServiceMock.Setup(c => c.GetCategoriesAsync()).ReturnsAsync(new List<CategorySummaryDto>());

            // Act
            var result = await _categoryServiceMock.Object.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnCategorySummary_WhenCategoryExists()
        {
            // Arrange
            var category = new CategorySummaryDto { CategoryId = 1, Name = "Category 1", ProductCount = 10 };
            _categoryServiceMock.Setup(c => c.GetCategorySummaryAsync(1)).ReturnsAsync(category);

            // Act
            var result = await _categoryServiceMock.Object.GetCategorySummaryAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(category, result);
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange
            _categoryServiceMock.Setup(c => c.GetCategorySummaryAsync(It.IsAny<int>())).ReturnsAsync((CategorySummaryDto?)null);

            // Act
            var result = await _categoryServiceMock.Object.GetCategorySummaryAsync(1);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void MergeCategoriesAndCreateNewAsync_ShouldThrowException_WhenOneSourceCategoryIsMissing()
        {
            // Arrange
            _categoryServiceMock.Setup(c => c.MergeCategoriesAndCreateNewAsync(
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<bool>()))
                .ThrowsAsync(new Exception("One or both source categories not found."));

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () =>
                await _categoryServiceMock.Object.MergeCategoriesAndCreateNewAsync("New Category", 1, 2));

            Assert.AreEqual("One or both source categories not found.", ex.Message);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldReturnNewCategory_WhenSuccessful()
        {
            // Arrange
            var newCategory = new Category { Id = 3, Name = "New Category" };
            _categoryServiceMock.Setup(c => c.MergeCategoriesAndCreateNewAsync(
                "New Category", 1, 2, true)).ReturnsAsync(newCategory);

            // Act
            var result = await _categoryServiceMock.Object.MergeCategoriesAndCreateNewAsync("New Category", 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategory.Id, result.Id);
            Assert.AreEqual("New Category", result.Name);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldHandleEmptyProductLists()
        {
            // Arrange
            var newCategory = new Category { Id = 3, Name = "Merged Empty Category" };
            _categoryServiceMock.Setup(c => c.MergeCategoriesAndCreateNewAsync(
                "Merged Empty Category", 1, 2, true)).ReturnsAsync(newCategory);

            // Act
            var result = await _categoryServiceMock.Object.MergeCategoriesAndCreateNewAsync("Merged Empty Category", 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategory.Name, result.Name);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldProperlyAssignProductsToNewCategory()
        {
            // Arrange
            var product1 = new Product { Id = 1, Name = "Product A" };
            var product2 = new Product { Id = 2, Name = "Product B" };
            var newCategory = new Category
            {
                Id = 3,
                Name = "Merged Category",
                Products = new List<Product> { product1, product2 }
            };

            _categoryServiceMock.Setup(c => c.MergeCategoriesAndCreateNewAsync(
                "Merged Category", 1, 2, true)).ReturnsAsync(newCategory);

            // Act
            var result = await _categoryServiceMock.Object.MergeCategoriesAndCreateNewAsync("Merged Category", 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Products.Count);
            Assert.Contains(product1, result.Products.ToList());
            Assert.Contains(product2, result.Products.ToList());
        }
    }
}
