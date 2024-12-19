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
            // Create a mock DbContext with seeded data using MockDbContext
            _context = MockDbContext.GenerateMock();  // Use the MockDbContext to create a DbContext with seeded data

            // Initialize the CategoryService with the mock DbContext
            _service = new CategoryService(_context);
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnCategories()
        {
            // Arrange: The categories are already seeded in MockDbContext
            // No need to mock the DbSet directly, data is seeded via the MockDbContext

            // Act
            var result = await _service.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);  // Verifying the result contains 3 categories (as seeded in MockDbContext)
        }

        [Test]
        public async Task GetCategoriesAsync_ShouldReturnEmptyList_WhenNoCategoriesExist()
        {
            // Arrange: Clear the Categories in the context to simulate an empty database
            _context.Products.RemoveRange(_context.Products.ToList());
            _context.Categories.RemoveRange(_context.Categories.ToList()); // Remove all categories to simulate an empty list
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetCategoriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);  // Verifying the result is an empty list
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnCategorySummary_WhenCategoryExists()
        {
            // Act
            var result = await _service.GetCategorySummaryAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual("Electronics", result.Name);
            Assert.AreEqual(1, result.ProductCount); // Verifying the count of products
        }

        [Test]
        public async Task GetCategorySummaryAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange: Ensure the database does not contain the category
            _context.Products.RemoveRange(_context.Products.ToList());
            _context.Categories.RemoveRange(_context.Categories);
            await _context.SaveChangesAsync(); // Ensure changes are persisted

            // Act
            var result = await _service.GetCategorySummaryAsync(1); // Attempt to fetch a non-existent category

            // Assert
            Assert.IsNull(result); // Verifying the result is null
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldThrowException_WhenOneSourceCategoryIsMissing()
        {
            // Act & Assert: Try to merge categories with one missing
            var ex = Assert.ThrowsAsync<Exception>(async () =>
                await _service.MergeCategoriesAndCreateNewAsync("New Category", 1, 20, false));

            Assert.AreEqual("One or both source categories not found.", ex.Message);
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldReturnNewCategory_WhenSuccessful()
        {
            // Arrange: Ensure the mock data contains the required categories
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

            // Verify that the new category is saved in the database
            var savedCategory = _context.Categories.SingleOrDefault(c => c.Name == newCategoryName);
            Assert.IsNotNull(savedCategory);
            Assert.AreEqual(newCategoryName, savedCategory.Name);

            // Optionally verify that the source categories were merged or removed
            var sourceCategories = _context.Categories.Where(c => c.Id == 1 || c.Id == 2).ToList();
            Assert.IsEmpty(sourceCategories); // Assuming source categories are removed after merging
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldHandleEmptyProductLists()
        {
            // Arrange: Ensure the mock data contains the required categories
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

            // Verify that the new category is saved in the database
            var savedCategory = _context.Categories.SingleOrDefault(c => c.Name == newCategoryName);
            Assert.IsNotNull(savedCategory);

            // Verify that source categories were removed
            var sourceCategories = _context.Categories.Where(c => c.Id == 1 || c.Id == 2).ToList();
            Assert.IsEmpty(sourceCategories);

            // Verify that no products were erroneously added to the new category
            var productsForNewCategory = _context.Products.Where(p => p.CategoryId == savedCategory.Id).ToList();
            Assert.IsEmpty(productsForNewCategory, "The new category should have no associated products.");
        }

        [Test]
        public async Task MergeCategoriesAndCreateNewAsync_ShouldProperlyAssignProductsToNewCategory()
        {
            // Arrange: Fetch categories from the mock data
            var category1 = _context.Categories.SingleOrDefault(c => c.Id == 1);
            var category2 = _context.Categories.SingleOrDefault(c => c.Id == 2);
            Assert.IsNotNull(category1, "Category 1 is missing in the mock data.");
            Assert.IsNotNull(category2, "Category 2 is missing in the mock data.");

            // Associate mock products with the source categories
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
            Assert.AreEqual(2, reassignedProducts.Count);
            Assert.Contains(product1, reassignedProducts);
            Assert.Contains(product2, reassignedProducts);

            // Verify that the source categories are removed
            var sourceCategories = _context.Categories.Where(c => c.Id == 1 || c.Id == 2).ToList();
            Assert.IsEmpty(sourceCategories, "Source categories should be removed after merging.");
        }
    }
}