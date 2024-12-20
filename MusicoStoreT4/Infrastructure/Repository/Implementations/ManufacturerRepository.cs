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
    public class ManufacturerRepository : IManufacturerRepository
    {
        public Task<Manufacturer?> Add(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Manufacturer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Manufacturer?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Manufacturer entity)
        {
            throw new NotImplementedException();
        }
    }
}
