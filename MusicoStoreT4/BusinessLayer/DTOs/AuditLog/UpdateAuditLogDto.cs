namespace BusinessLayer.DTOs.Category
{
    public class UpdateAuditLogDto
    {
        public required int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Action { get; set; }
        public int? ModifiedById { get; set; }
    }
}
