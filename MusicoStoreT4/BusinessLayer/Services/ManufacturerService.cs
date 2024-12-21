using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class ManufacturerService : BaseService, IManufacturerService
    {
        private readonly IUnitOfWork _uow;

        public ManufacturerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<bool> ValidateManufacturerAsync(int manufacturerId)
        {
            return await _uow.ManufacturersRep
                .AnyAsync(m => m.Id == manufacturerId);
        }

        public async Task DeleteManufacturerAsync(int manufacturerId)
        {
            var manufacturer = (await _uow.ManufacturersRep.WhereAsync(m => m.Id == manufacturerId)).FirstOrDefault();

            if (manufacturer == null)
            {
                return;
            }

            await _uow.ManufacturersRep.DeleteAsync(manufacturer.Id);
            await _uow.SaveAsync();
        }
    }
}
