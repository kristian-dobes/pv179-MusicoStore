using DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        public PaymentStatus OrderStatus { get; set; }

        public int? GiftCardId { get; set; }
        public virtual GiftCard? GiftCard { get; set; }
    }
}
