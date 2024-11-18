namespace WebAPI.DTOs.Images
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
