using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementations
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        private readonly MyDBContext _context;

        public ProductImageRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductImage?> GetByProductIdAsync(int productId)
        {
            return await _context.ProductImages.FirstOrDefaultAsync(pi => pi.ProductId == productId);
        }

        public override async Task<bool> UpdateAsync(ProductImage entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingImage = await _context.ProductImages.FindAsync(entity.Id);

            if (existingImage == null)
                return false;

            existingImage.FilePath = entity.FilePath;
            existingImage.FileName = entity.FileName;
            existingImage.MimeType = entity.MimeType;
            existingImage.ProductId = entity.ProductId;

            _context.ProductImages.Update(existingImage);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
