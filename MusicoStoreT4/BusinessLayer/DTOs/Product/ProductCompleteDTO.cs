﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Product
{
    public class ProductCompleteDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int LastModifiedById { get; set; }
        public int EditCount { get; set; }
        public ICollection<OrderItemCompleteDTO>? OrderItems { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
    }
}
