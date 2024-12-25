using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.Models.Enums;

namespace DataAccessLayer.Data
{
    public class AuditSaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly List<(Product Entity, EntityState State)> _cachedEntities = new();

        public AuditSaveChangesInterceptor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context != null)
            {
                // Cache the entities and their states
                var changedEntities = context.ChangeTracker.Entries<Product>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

                _cachedEntities.Clear();
                foreach (var entry in changedEntities)
                {
                    _cachedEntities.Add((entry.Entity, entry.State));
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context == null)
            {
                return await base.SavedChangesAsync(eventData, result, cancellationToken);
            }

            // Use the cached entities for logging
            foreach (var (entity, state) in _cachedEntities)
            {
                var action = state == EntityState.Added ? AuditAction.Create
                                                         : state == EntityState.Modified
                                                             ? AuditAction.Update : AuditAction.Delete;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var auditLogService = scope.ServiceProvider.GetRequiredService<IAuditLogService>();
                    await auditLogService.LogAsync(entity.Id, action, entity.LastModifiedById);
                }
            }

            _cachedEntities.Clear(); // Clean up after processing

            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}
