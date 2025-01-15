using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }

        public int? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
