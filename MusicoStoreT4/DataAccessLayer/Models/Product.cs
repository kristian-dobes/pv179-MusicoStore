using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public virtual IEnumerable<OrderItem>? OrderItems { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
    }
}
