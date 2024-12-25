using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class LogService : BaseService, ILogService
    {
        private readonly IUnitOfWork _uow;

        public LogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task LogRequestAsync(string method, string path, RequestSource source)
        {
            var log = new Log
            {
                Method = method,
                Path = path,
                Created = DateTime.UtcNow,
                Source = source
            };

            await _uow.LogsRep.AddAsync(log);
            await SaveAsync(true);
        }
    }
}
