using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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

        public async Task LogRequestAsync(string method, string path)
        {
            var log = new Log
            {
                Method = method,
                Path = path,
                Created = DateTime.UtcNow
            };

            await _uow.LogsRep.AddAsync(log);
            await SaveAsync(true);
        }
    }
}
