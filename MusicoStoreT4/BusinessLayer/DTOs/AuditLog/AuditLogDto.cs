namespace BusinessLayer.DTOs.Category
{
    public class AuditLogDto
    {
        public int ProductId { get; set; }
        public string Action { get; set; }
        public int ModifiedById { get; set; }
    }
}
