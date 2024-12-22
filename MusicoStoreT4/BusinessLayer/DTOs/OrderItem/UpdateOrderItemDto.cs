﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.OrderItem
{
    public class UpdateOrderItemDto
    {
        public required int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
