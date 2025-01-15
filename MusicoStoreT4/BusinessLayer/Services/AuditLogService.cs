using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.UnitOfWork;

namespace BusinessLayer.Services
{
    public class AuditLogService : BaseService, IAuditLogService
    {
        private readonly IUnitOfWork _uow;

        public AuditLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task LogAsync(IEnumerable<AuditLog> auditLogs)
        {
            if (auditLogs == null || !auditLogs.Any())
                throw new ArgumentException("No audit logs provided.", nameof(auditLogs));

            try
            {
                await _uow.ProductAuditsRep.AddRangeAsync(auditLogs); // Bulk insert
                await _uow.SaveAsync(); // Single save call
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to log audit entries.", ex);
            }
        }

        public async Task LogAsync(int productId, AuditAction action, int modifiedBy)
        {
            await LogAsync(new List<AuditLog>
            {
                new AuditLog
                {
                    ProductId = productId,
                    Action = action,
                    ModifiedById = modifiedBy,
                    Created = DateTime.UtcNow
                }
            });
        }
    }
}
