using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product>? PrimaryProducts { get; set; } = new List<Product>();
        public virtual ICollection<Product>? SecondaryProducts { get; set; } = new List<Product>();
    }
}
