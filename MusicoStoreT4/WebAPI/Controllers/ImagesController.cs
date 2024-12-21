﻿using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using WebAPI.DTOs.Images;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IImageService _imageService;

        public ImagesController(MyDBContext context, IWebHostEnvironment webHostEnvironment, IImageService productService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imageService = productService;
        }

        [HttpGet("images")]
        public async Task<IActionResult> Fetch()
        {
            var images = await _imageService.GetAllProductsImagesAsync();

            if (images == null || !images.Any())
            {
                return NotFound(new { Message = "No images found." });
            }

            var fileResults = images.Select(image =>
            {
                var fileBytes = image.FileContents;
                var mimeType = image.MimeType;
                var fileName = image.FileName;

                return new FileContentResult(fileBytes, mimeType)
                {
                    FileDownloadName = fileName
                };
            }).ToList();

            return Ok(fileResults.Select(fileResult => new
            {
                fileResult.FileDownloadName,
                fileResult.ContentType,
                FileBytes = Convert.ToBase64String(fileResult.FileContents)
            }));
        }

        [HttpPost("UploadMetadata")]
        public async Task<IActionResult> UploadImageMetadata([FromBody] UploadImageMetadataDTO uploadImageMetadataDTO)
        {
            if (uploadImageMetadataDTO == null)
                return BadRequest("Image metadata must be provided.");

            var productImage = new ProductImage
            {
                ProductId = uploadImageMetadataDTO.ProductId,
                Created = DateTime.UtcNow,
                FilePath = uploadImageMetadataDTO.FilePath,
                FileName = uploadImageMetadataDTO.FileName,
                MimeType = uploadImageMetadataDTO.MimeType
            };

            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();

            var productImageDTO = new ProductImageDTO
            {
                Id = productImage.Id,
                ProductId = productImage.ProductId,
                FilePath = productImage.FilePath,
                FileName = productImage.FileName,
                MimeType = productImage.MimeType,
                CreatedAt = productImage.Created
            };

            return Ok(productImageDTO);
        }

        [HttpGet("{productId}/file")]
        public async Task<IActionResult> GetImageFileByProductId(int productId)
        {
            var image = await _imageService.GetProductImageAsync(productId);

            if (image == null)
            {
                return NotFound(new { Message = "Image not found for this product." });
            }

            return File(image.FileContents, image.MimeType, image.FileName);
        }

        [HttpPost("upload-image/{productId}")]
        public async Task<IActionResult> UploadImageForProduct(int productId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            bool isImageUploaded = await _imageService.ChangeOrAssignProductImageAsync(productId, file);

            if (!isImageUploaded)
            {
                return BadRequest("Failed to upload image.");
            }

            return Ok(new { message = "Image uploaded successfully." });
        }

        [HttpPut("change-image/{productId}")]
        public async Task<IActionResult> ChangeProductImage(int productId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var updated = await _imageService.ChangeOrAssignProductImageAsync(productId, file);

            if (!updated)
            {
                return NotFound($"Image with for product with ID {productId} not found.");
            }

            return NoContent();
        }

        [HttpDelete("delete-image/{productId}")]
        public async Task<IActionResult> DeleteProductImage(int productId)
        {
            var deleted = await _imageService.DeleteProductImageAsync(productId);

            if (!deleted)
            {
                return NotFound($"Image for product with ID {productId} not found.");
            }

            return NoContent();
        }
    }
}
