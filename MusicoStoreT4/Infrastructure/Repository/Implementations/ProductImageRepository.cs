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
    public class ProductImageRepository : IProductImageRepository
    {
        public Task<ProductImage?> Add(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductImage?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ProductImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
