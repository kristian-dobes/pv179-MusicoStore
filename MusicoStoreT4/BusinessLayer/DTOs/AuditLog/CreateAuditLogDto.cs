namespace BusinessLayer.DTOs.Category
{
    public class CreateAuditLogDto
    {
        public int ProductId { get; set; }
        public string Action { get; set; }
        public int ModifiedById { get; set; }
    }
}
