using BusinessLayer.Enums;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AuditLogService : BaseService, IAuditLogService
    {
        private readonly IUnitOfWork _uow;

        public AuditLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task LogAsync(int productId, AuditAction action, int modifiedBy)
        {
            if (productId <= 0)
                throw new ArgumentException("Invalid product ID.", nameof(productId));

            var auditLog = new AuditLog
            {
                ProductId = productId,
                Action = action.ToString(),
                ModifiedById = modifiedBy,
                Created = DateTime.UtcNow
            };

            try
            {
                await _uow.ProductAuditsRep.AddAsync(auditLog);
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to log audit entry.", ex);
            }
        }
    }
}
