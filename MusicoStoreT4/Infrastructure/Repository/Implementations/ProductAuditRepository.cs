using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductAuditRepository : IProductAuditRepository
    {
        public Task<AuditLog?> Add(AuditLog entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuditLog>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuditLog?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AuditLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
