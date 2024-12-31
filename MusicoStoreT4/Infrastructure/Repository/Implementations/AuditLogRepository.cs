using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository.Implementations
{
    public class AuditLogRepository : Repository<AuditLog>, IAuditLogRepository
    {
        private readonly MyDBContext _context;

        public AuditLogRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(AuditLog entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingAuditLog = await _context.AuditLogs.FindAsync(entity.Id);

            if (existingAuditLog == null)
                return false;

            existingAuditLog.ProductId = entity.ProductId;
            existingAuditLog.Action = entity.Action;
            existingAuditLog.ModifiedById = entity.ModifiedById;

            _context.AuditLogs.Update(existingAuditLog);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task AddRangeAsync(IEnumerable<AuditLog> auditLogs)
        {
            if (auditLogs == null)
                throw new ArgumentNullException(nameof(auditLogs));

            await _context.Set<AuditLog>().AddRangeAsync(auditLogs);
        }
    }
}
