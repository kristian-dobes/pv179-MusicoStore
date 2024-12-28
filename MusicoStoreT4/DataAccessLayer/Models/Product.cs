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
        public int LastModifiedById { get; set; } // TODO add User entity
        public int EditCount { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        public int PrimaryCategoryId { get; set; }

        [ForeignKey(nameof(PrimaryCategoryId))]
        public virtual Category? PrimaryCategory { get; set; }

        public virtual ICollection<Category>? SecondaryCategories { get; set; } =
            new List<Category>();

        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer? Manufacturer { get; set; }

        public virtual ProductImage? Image { get; set; }
    }
}
