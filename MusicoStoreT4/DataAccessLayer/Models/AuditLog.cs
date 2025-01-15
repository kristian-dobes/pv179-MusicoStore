using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Models
{
    public class AuditLog : BaseEntity
    {
        public int ProductId { get; set; }
        public AuditAction Action { get; set; }
        public int ModifiedById { get; set; }
    }
}
