using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ProductImage : BaseEntity
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }
    }
}
