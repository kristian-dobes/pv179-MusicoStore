using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
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
        private readonly MyDBContext _dBContext;

        public LogService(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task LogRequestAsync(string method, string path)
        {
            var log = new Log
            {
                Method = method,
                Path = path,
                Created = DateTime.UtcNow
            };

            _dBContext.Logs.Add(log);
            await SaveAsync(true);
        }
    }
}
