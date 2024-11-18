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

        public ImagesController(MyDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            // Fetch the product image record from the database
            var productImage = await _context.ProductImages
                .FirstOrDefaultAsync(pi => pi.ProductId == productId);

            if (productImage == null)
            {
                return NotFound(new { Message = "Image not found for this product." });
            }

            // Construct the full file path for the image, using ContentRootPath
            // Example: images folder at the root of the project
            var imageFolderPath = _webHostEnvironment.ContentRootPath;
            var filePath = Path.Combine(imageFolderPath, productImage.FilePath);

            // Check if the file exists before trying to read it
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(new { Message = "Image file not found on server." });
            }

            // Read the file content
            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            // Return the file content with the correct MIME type
            return File(fileBytes, productImage.MimeType);
        }
    }
}
