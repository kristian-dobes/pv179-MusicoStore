using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IAuditLogRepository : IRepository<AuditLog>
    {
        Task AddRangeAsync(IEnumerable<AuditLog> auditLogs);
    }
}
