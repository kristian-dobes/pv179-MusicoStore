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

        public async Task MergeManufacturersAsync(int sourceManufacturerId, int destinationManufacturerId, int modifiedById)
        {
            if (sourceManufacturerId == destinationManufacturerId)
            {
                throw new InvalidOperationException("Source and target manufacturers must be different.");
            }

            var sourceExists = await _manufacturerService.ValidateManufacturerAsync(sourceManufacturerId);
            var targetExists = await _manufacturerService.ValidateManufacturerAsync(destinationManufacturerId);

            if (!sourceExists)
            {
                throw new KeyNotFoundException($"Source manufacturer with ID {sourceManufacturerId} not found.");
            }

            if (!targetExists)
            {
                throw new KeyNotFoundException($"Target manufacturer with ID {destinationManufacturerId} not found.");
            }

            await _productService.ReassignProductsToManufacturerAsync(sourceManufacturerId, destinationManufacturerId, modifiedById);
            await _manufacturerService.DeleteManufacturerAsync(sourceManufacturerId);
        }
    }
}
