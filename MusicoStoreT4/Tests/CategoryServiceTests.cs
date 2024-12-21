using BusinessLayer.DTOs;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tests.Other;

namespace Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private Mock<IUnitOfWork> _uowMock;
        private CategoryService _service;

        [SetUp]
        public void SetUp()
        {
            _uowMock = new Mock<IUnitOfWork>();
            _service = new CategoryService(_uowMock.Object);
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnCategories()
        {
            // Act
            var result = await _service.GetCategoriesSummariesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange
            _uowMock.Setup(uow => uow.CategoriesRep.GetAllAsync()).ReturnsAsync(new List<Category>());

            // Act
            var result = await _service.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);

            // Verify that GetAllAsync was called once on the Categories repository
            _uowMock.Verify(uow => uow.CategoriesRep.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnCategorySummary_WhenCategoryExists()
        {
            CategorySummaryDto categorySummaryDto = new CategorySummaryDto
            {
                CategoryId = 1,
                Name = "Guitars",
                ProductCount = 2
            };

            // Act
            _uowMock.Setup(uow => uow.CategoriesRep.GetCategorySummaryAsync(It.IsAny<int>())).ReturnsAsync(categorySummaryDto);
            var result = await _service.GetCategorySummaryAsync(1);

            // Assert
            Assert.IsNotNull(categorySummaryDto);
            Assert.AreEqual(1, categorySummaryDto.CategoryId);
            Assert.AreEqual("Guitars", categorySummaryDto.Name);
            Assert.AreEqual(2, categorySummaryDto.ProductCount);
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange
            _uowMock.Setup(uow => uow.CategoriesRep.GetCategorySummaryAsync(It.IsAny<int>())).ReturnsAsync((CategorySummaryDto)null);

            // Act
            var result = await _service.GetCategorySummaryAsync(1);

            // Assert
            Assert.IsNull(result);

            _uowMock.Verify(uow => uow.CategoriesRep.GetCategorySummaryAsync(1), Times.Once);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldThrowException_WhenOneSourceCategoryIsMissing()
        {
            Category category1 = new Category { Id = 1, Name = "Guitars" };

            // Arrange
            _uowMock.Setup(uow => uow.CategoriesRep.GetByIdAsync(1)).ReturnsAsync(category1);
            _uowMock.Setup(uow => uow.CategoriesRep.GetByIdAsync(20)).ReturnsAsync((Category)null);

            // Act
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _service.MergeCategoriesAndCreateNewAsync("New Category", 1, 20, false));

            // Assert
            Assert.AreEqual("One or both source categories not found.", ex.Message);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldReturnNewCategory_WhenSuccessful()
        {
            // Arrange
            var category1 = new Category { Id = 1, Name = "Guitars" };
            var category2 = new Category { Id = 2, Name = "Drums" };

            _uowMock.Setup(uow => uow.CategoriesRep.WhereAsync(It.Is<Expression<Func<Category, bool>>>(expr => expr.Compile().Invoke(category1))))
                .ReturnsAsync(new List<Category> { category1 });

            _uowMock.Setup(uow => uow.CategoriesRep.WhereAsync(It.Is<Expression<Func<Category, bool>>>(expr => expr.Compile().Invoke(category2))))
                .ReturnsAsync(new List<Category> { category2 });

            var newCategoryName = "New Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            _uowMock.Verify(uow => uow.CategoriesRep.AddAsync(It.Is<Category>(c => c.Name == newCategoryName)), Times.Once);
            _uowMock.Verify(uow => uow.CategoriesRep.DeleteAsync(1), Times.Once);
            _uowMock.Verify(uow => uow.CategoriesRep.DeleteAsync(2), Times.Once);
            _uowMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldHandleEmptyProductLists()
        {
            // Arrange
            var category1 = new Category { Id = 1, Name = "Guitars" };
            var category2 = new Category { Id = 2, Name = "Drums" };

            _uowMock.Setup(uow => uow.CategoriesRep.WhereAsync(It.Is<Expression<Func<Category, bool>>>(expr => expr.Compile().Invoke(category1))))
                .ReturnsAsync(new List<Category> { category1 });
            _uowMock.Setup(uow => uow.CategoriesRep.WhereAsync(It.Is<Expression<Func<Category, bool>>>(expr => expr.Compile().Invoke(category2))))
                .ReturnsAsync(new List<Category> { category2 });

            _uowMock.Setup(uow => uow.ProductsRep.WhereAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(new List<Product>());  // Empty product list

            var newCategoryName = "Merged Empty Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            _uowMock.Verify(uow => uow.CategoriesRep.AddAsync(It.Is<Category>(c => c.Name == newCategoryName)), Times.Once);
            _uowMock.Verify(uow => uow.CategoriesRep.DeleteAsync(1), Times.Once);
            _uowMock.Verify(uow => uow.CategoriesRep.DeleteAsync(2), Times.Once);
            _uowMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldProperlyAssignProductsToNewCategory()
        {
            // Arrange
            var category1 = new Category { Id = 1, Name = "Guitars" };
            var category2 = new Category { Id = 2, Name = "Drums" };

            var product1 = new Product
            {
                Id = 1,
                Name = "Fender Stratocaster"
            };

            var product2 = new Product
            {
                Id = 3,
                Name = "Yamaha Acoustic Drum Kit"
            };

            _uowMock.Setup(uow => uow.CategoriesRep.WhereAsync(It.Is<Expression<Func<Category, bool>>>(expr => expr.Compile().Invoke(category1))))
                .ReturnsAsync(new List<Category> { category1 });
            _uowMock.Setup(uow => uow.CategoriesRep.WhereAsync(It.Is<Expression<Func<Category, bool>>>(expr => expr.Compile().Invoke(category2))))
                .ReturnsAsync(new List<Category> { category2 });

            _uowMock.Setup(uow => uow.ProductsRep.WhereAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(new List<Product> { product1, product2 });

            var newCategoryName = "Merged Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            _uowMock.Verify(uow => uow.CategoriesRep.AddAsync(It.Is<Category>(c => c.Name == newCategoryName)), Times.Once);
            _uowMock.Verify(uow => uow.CategoriesRep.DeleteAsync(1), Times.Once);
            _uowMock.Verify(uow => uow.CategoriesRep.DeleteAsync(2), Times.Once);
            _uowMock.Verify(uow => uow.SaveAsync(), Times.Once);

            var reassignedProducts = _uowMock.Object.ProductsRep.WhereAsync(It.IsAny<Expression<Func<Product, bool>>>())
                .Result.Where(p => p.CategoryId == result.Id).ToList();
            Assert.AreEqual(2, reassignedProducts.Count);
            Assert.Contains(product1, reassignedProducts);
            Assert.Contains(product2, reassignedProducts);
        }
    }
}