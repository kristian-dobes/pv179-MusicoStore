using BusinessLayer.Services.Interfaces;
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

        [HttpGet("{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var filePath = Path.Combine("images", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var mimeType = "image/jpeg"; // Default mime type for images

            if (fileName.EndsWith(".png"))
                mimeType = "image/png";
            else if (fileName.EndsWith(".gif"))
                mimeType = "image/gif";
            else if (fileName.EndsWith(".bmp"))
                mimeType = "image/bmp";

            return File(fileBytes, mimeType);
        }

        [HttpGet("{productId}/file")]
        public async Task<IActionResult> GetImageFileByProductId(int productId)
        {
            var productImage = await _context.ProductImages
                .FirstOrDefaultAsync(pi => pi.ProductId == productId);

            if (productImage == null)
            {
                return NotFound(new { Message = "Image not found for this product." });
            }

            if (!System.IO.File.Exists(productImage.FilePath))
            {
                return NotFound(new { Message = "Image file not found on server." });
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(productImage.FilePath);
            return File(fileBytes, productImage.MimeType);
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
