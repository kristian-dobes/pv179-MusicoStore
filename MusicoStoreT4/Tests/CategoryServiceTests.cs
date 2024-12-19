using BusinessLayer.DTOs;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Other;

namespace Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private MyDBContext _context;
        private CategoryService _service;

        [SetUp]
        public void SetUp()
        {
            _context = MockDbContext.GenerateMock();
            _service = new CategoryService(_context);
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnCategories()
        {
            // Act
            var result = await _service.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            _context.Products.RemoveRange(_context.Products.ToList());
            _context.Categories.RemoveRange(_context.Categories.ToList());
            await _context.SaveChangesAsync();

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
            var result = await _service.GetCategorySummaryAsync(1);

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
            _context.Products.RemoveRange(_context.Products.ToList());
            _context.Categories.RemoveRange(_context.Categories);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetCategorySummaryAsync(1);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldThrowException_WhenOneSourceCategoryIsMissing()
        {
            var ex = Assert.ThrowsAsync<Exception>(async () =>
                await _service.MergeCategoriesAndCreateNewAsync("New Category", 1, 20, false));

            Assert.AreEqual("One or both source categories not found.", ex.Message);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldReturnNewCategory_WhenSuccessful()
        {
            // Arrange
            var category1 = _context.Categories.SingleOrDefault(c => c.Id == 1);
            var category2 = _context.Categories.SingleOrDefault(c => c.Id == 2);
            Assert.IsNotNull(category1, "Category 1 is missing in the mock data.");
            Assert.IsNotNull(category2, "Category 2 is missing in the mock data.");

            var newCategoryName = "New Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            var savedCategory = _context.Categories.SingleOrDefault(c => c.Name == newCategoryName);
            Assert.IsNotNull(savedCategory);
            Assert.AreEqual(newCategoryName, savedCategory.Name);

            var sourceCategories = _context.Categories.Where(c => c.Id == 1 || c.Id == 2).ToList();
            Assert.IsEmpty(sourceCategories);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldHandleEmptyProductLists()
        {
            // Arrange
            var category1 = _context.Categories.SingleOrDefault(c => c.Id == 1);
            var category2 = _context.Categories.SingleOrDefault(c => c.Id == 2);

            Assert.IsNotNull(category1, "Category 1 is missing in the mock data.");
            Assert.IsNotNull(category2, "Category 2 is missing in the mock data.");

            _context.Products.RemoveRange(_context.Products.ToList());
            await _context.SaveChangesAsync(); // Ensure changes are persisted

            var newCategoryName = "Merged Empty Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(
                newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            var savedCategory = _context.Categories.SingleOrDefault(c => c.Name == newCategoryName);
            Assert.IsNotNull(savedCategory);

            var sourceCategories = _context.Categories.Where(c => c.Id == 1 || c.Id == 2).ToList();
            Assert.IsEmpty(sourceCategories);

            var productsForNewCategory = _context.Products.Where(p => p.CategoryId == savedCategory.Id).ToList();
            Assert.IsEmpty(productsForNewCategory, "The new category should have no associated products.");
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldProperlyAssignProductsToNewCategory()
        {
            // Arrange
            var category1 = _context.Categories.SingleOrDefault(c => c.Id == 1);
            var category2 = _context.Categories.SingleOrDefault(c => c.Id == 2);
            Assert.IsNotNull(category1, "Category 1 is missing in the mock data.");
            Assert.IsNotNull(category2, "Category 2 is missing in the mock data.");

            var product1 = _context.Products.SingleOrDefault(p => p.Id == 1);
            var product2 = _context.Products.SingleOrDefault(p => p.Id == 2);
            Assert.IsNotNull(product1, "Product 1 is missing in the mock data.");
            Assert.IsNotNull(product2, "Product 2 is missing in the mock data.");
            product1.CategoryId = category1.Id;
            product2.CategoryId = category2.Id;

            await _context.SaveChangesAsync();

            var newCategoryName = "Merged Category";

            // Act
            var result = await _service.MergeCategoriesAndCreateNewAsync(newCategoryName, 1, 2, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newCategoryName, result.Name);

            // Verify that the new category is saved in the database
            var savedCategory = _context.Categories.SingleOrDefault(c => c.Name == newCategoryName);
            Assert.IsNotNull(savedCategory);

            // Verify that the products are reassigned to the new category
            var reassignedProducts = _context.Products.Where(p => p.CategoryId == savedCategory.Id).ToList();
            Assert.AreEqual(3, reassignedProducts.Count);
            Assert.Contains(product1, reassignedProducts);
            Assert.Contains(product2, reassignedProducts);

            // Verify that the source categories are removed
            var sourceCategories = _context.Categories.Where(c => c.Id == 1 || c.Id == 2).ToList();
            Assert.IsEmpty(sourceCategories, "Source categories should be removed after merging.");
        }
    }
}