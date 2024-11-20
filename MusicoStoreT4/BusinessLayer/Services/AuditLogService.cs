using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly MyDBContext _context;

        public AuditLogService(MyDBContext context)
        {
            _context = context;
        }

        public async Task LogAsync(int productId, string action, int modifiedBy)
        {
            var auditLog = new AuditLog
            {
                ProductId = productId,
                Action = action,
                ModifiedBy = modifiedBy,
                Created = DateTime.UtcNow
            };

            await _context.AuditLogs.AddAsync(auditLog);
            await _context.SaveChangesAsync();
        }
    }
}
