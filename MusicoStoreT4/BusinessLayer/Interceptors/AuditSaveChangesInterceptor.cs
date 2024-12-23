using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.Enums;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Data
{
    public class AuditSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IServiceProvider _serviceProvider;

        public AuditSaveChangesInterceptor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            
            if (context == null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            var changedEntities = context.ChangeTracker.Entries<Product>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            foreach (var entity in changedEntities)
            {
                var action = entity.State == EntityState.Added ? AuditAction.Create
                                                               : entity.State == EntityState.Modified
                                                                    ? AuditAction.Update : AuditAction.Delete;
                using (var scope = _serviceProvider.CreateScope())
                {
                    var auditLogService = scope.ServiceProvider.GetRequiredService<IAuditLogService>();
                    auditLogService.LogAsync(entity.Entity.Id, action, entity.Entity.LastModifiedById).Wait();
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
