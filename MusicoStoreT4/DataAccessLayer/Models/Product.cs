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

        /// <summary>
        /// -1 means it was last modified by Web API
        /// </summary>
        public int LastModifiedById { get; set; }
        public int EditCount { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }

        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer? Manufacturer { get; set; }
    }
}
