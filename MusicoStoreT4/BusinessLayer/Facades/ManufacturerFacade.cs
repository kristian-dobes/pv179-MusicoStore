using BusinessLayer.Facades.Interfaces;
using BusinessLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Facades
{
    public class ManufacturerFacade : IManufacturerFacade
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductService _productService;

        public ManufacturerFacade(IManufacturerService manufacturerService, IProductService productService)
        {
            _manufacturerService = manufacturerService;
            _productService = productService;
        }

        public async Task MergeManufacturersAsync(int sourceManufacturerId, int targetManufacturerId, int modifiedById)
        {
            if (sourceManufacturerId == targetManufacturerId)
            {
                throw new InvalidOperationException("Source and target manufacturers must be different.");
            }

            var sourceExists = await _manufacturerService.ValidateManufacturerAsync(sourceManufacturerId);
            var targetExists = await _manufacturerService.ValidateManufacturerAsync(targetManufacturerId);

            if (!sourceExists)
            {
                throw new KeyNotFoundException($"Source manufacturer with ID {sourceManufacturerId} not found.");
            }

            if (!targetExists)
            {
                throw new KeyNotFoundException($"Target manufacturer with ID {targetManufacturerId} not found.");
            }

            await _productService.ReassignProductsToManufacturerAsync(sourceManufacturerId, targetManufacturerId, modifiedById);
            await _manufacturerService.DeleteManufacturerAsync(sourceManufacturerId);
        }
    }
}
