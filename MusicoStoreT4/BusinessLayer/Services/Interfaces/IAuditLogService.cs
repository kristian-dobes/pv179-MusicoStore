using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(IEnumerable<AuditLog> auditLogs);
        Task LogAsync(int productId, AuditAction action, int modifiedBy);
    }
}
