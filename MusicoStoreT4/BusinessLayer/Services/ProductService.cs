using BusinessLayer.DTOs.Product;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProductService : BaseService
    {
        private readonly MyDBContext _dBContext;

        public ProductService(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(
            DateTime startDate,
            DateTime endDate,
            int topN = 5)
        {
            var query = await (from orderItem in _dBContext.OrderItems
                               join product in _dBContext.Products on orderItem.ProductId equals product.Id
                               join category in _dBContext.Categories on product.CategoryId equals category.Id
                               where orderItem.Order.Date >= startDate && orderItem.Order.Date <= endDate
                               group new { orderItem, product } by new { category.Id, category.Name } into categoryGroup
                               select new TopSellingProductDto
                               {
                                   CategoryId = categoryGroup.Key.Id,
                                   CategoryName = categoryGroup.Key.Name,
                                   Products = categoryGroup
                                       .GroupBy(g => new { g.product.Id, g.product.Name })
                                       .Select(productGroup => new ProductSalesDto
                                       {
                                           ProductId = productGroup.Key.Id,
                                           ProductName = productGroup.Key.Name,
                                           TotalUnitsSold = productGroup.Sum(x => x.orderItem.Quantity),
                                           Revenue = productGroup.Sum(x => x.orderItem.Quantity * x.orderItem.Price)
                                       })
                                       .OrderByDescending(p => p.TotalUnitsSold)
                                       .Take(topN)
                                       .ToList()
                               }).ToListAsync();

            return query;
        }
    }
}
