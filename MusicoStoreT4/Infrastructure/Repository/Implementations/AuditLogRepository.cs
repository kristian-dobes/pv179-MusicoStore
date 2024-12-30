﻿using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
