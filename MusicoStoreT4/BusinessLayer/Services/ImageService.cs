﻿using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Services
{
    public class ImageService : BaseService, IImageService
    {
        private readonly MyDBContext _dbContext;
        private string _imagesFolder;

        public ImageService(MyDBContext dBContext, string imagesFolder) : base(dBContext)
        {
            _dbContext = dBContext;
            _imagesFolder = imagesFolder;
        }

        public Task<Product> CreateImageAsync(Product model, string createdBy)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetImagePathByProductIdAsync(int productId)
        {
            var productImage = await _dbContext.ProductImages
                .FirstOrDefaultAsync(pi => pi.ProductId == productId);

            if (productImage == null)
                return null;

            return productImage.FilePath;
        }

        public async Task<FileResult> GetProductImageAsync(int productId)
        {
            var product = await _dbContext.Products
                .Include(p => p.Image)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null || product.Image == null || !File.Exists(product.Image.FilePath))
            {
                return null;
            }

            var fileBytes = await File.ReadAllBytesAsync(product.Image.FilePath);

            return new FileContentResult(fileBytes, product.Image.MimeType)
            {
                FileDownloadName = product.Image.FileName
            };
        }

        public async Task<List<FileResult>> GetAllProductsImagesAsync()
        {
            var images = await _dbContext.ProductImages.ToListAsync();

            if (images == null || images.Count == 0)
            {
                return new List<FileResult>();
            }

            var results = new List<FileResult>();

            foreach (var image in images)
            {
                if (string.IsNullOrEmpty(image.FilePath) ||
                    string.IsNullOrEmpty(image.MimeType) ||
                    string.IsNullOrEmpty(image.FileName))
                {
                    continue;
                }

                if (!File.Exists(image.FilePath))
                {
                    continue;
                }

                try
                {
                    var fileBytes = await File.ReadAllBytesAsync(image.FilePath);
                    results.Add(new FileContentResult(fileBytes, image.MimeType)
                    {
                        FileDownloadName = image.FileName
                    });
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return results;
        }

        public async Task<bool> ChangeOrAssignProductImageAsync(int productId, IFormFile newFile)
        {
            if (newFile == null)
                throw new ArgumentNullException(nameof(newFile));

            var product = await _dbContext.Products
                .Include(p => p.Image)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                return false;

            if (product.Image != null)
            {
                if (File.Exists(product.Image.FilePath))
                {
                    File.Delete(product.Image.FilePath);
                }
            }
            else
            {
                product.Image = new ProductImage { ProductId = productId };
            }

            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(newFile.FileName)}";
            var newFilePath = Path.Combine(_imagesFolder, fileName);

            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await newFile.CopyToAsync(stream);
            }

            product.Image.FilePath = newFilePath;
            product.Image.FileName = Path.GetFileName(newFile.FileName);
            product.Image.MimeType = newFile.ContentType;

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductImageAsync(int productId)
        {
            var product = await _dbContext.Products
                .Include(p => p.Image)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null || product.Image == null)
            {
                return false;
            }

            if (File.Exists(product.Image.FilePath))
            {
                File.Delete(product.Image.FilePath);
            }

            _dbContext.ProductImages.Remove(product.Image);
            product.Image = null;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
