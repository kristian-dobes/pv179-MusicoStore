namespace BusinessLayer.DTOs
{
    public class ImageDto
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] FileContents { get; set; }
    }
}
