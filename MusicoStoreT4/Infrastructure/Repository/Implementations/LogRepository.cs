using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository.Implementations.Implementations
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        private readonly MyDBContext _context;

        public LogRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Logs should not be updated
        /// </summary>
        /// <returns>Always false</returns>
        public override Task<bool> UpdateAsync(Log entity)
        {
            return Task.FromResult(false);
        }
    }
}
