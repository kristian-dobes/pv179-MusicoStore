﻿using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly MyDBContext _context;

        public ProductImageRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<ProductImage?> Add(ProductImage entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var addedEntity = (await _context.ProductImages.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);

            if (productImage == null)
                return false;

            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductImage>> GetAll()
        {
            return await _context.ProductImages.ToListAsync();
        }

        public async Task<ProductImage?> GetById(int id)
        {
            return await _context.ProductImages.FirstOrDefaultAsync(pi => pi.Id == id);
        }

        public async Task<bool> Update(ProductImage entity)
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
