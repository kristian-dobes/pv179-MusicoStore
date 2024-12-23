using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementations.Implementations
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        private readonly MyDBContext _context;

        public LogRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(Log entity)
        {
            var existingLog = await _context.Logs.FindAsync(entity.Id);
            if (existingLog == null)
            {
                return false;
            }

            existingLog.Method = entity.Method;
            existingLog.Path = entity.Path;
            existingLog.Created = entity.Created;

            _context.Logs.Update(existingLog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
