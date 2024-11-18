namespace WebAPI.DTOs.Images
{
    public class UploadImageMetadataDTO
    {
        public int ProductId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}
