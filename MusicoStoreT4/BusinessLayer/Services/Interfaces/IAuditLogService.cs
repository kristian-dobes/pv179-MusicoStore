using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;

namespace BusinessLayer.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(IEnumerable<AuditLog> auditLogs);
        Task LogAsync(int productId, AuditAction action, int modifiedBy);
    }
}
