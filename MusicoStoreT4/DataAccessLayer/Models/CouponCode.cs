using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class CouponCode : BaseEntity
    {
        public string Code { get; set; }
        public bool IsUsed { get; set; }

        public int GiftCardId { get; set; }
        public virtual GiftCard GiftCard { get; set; }

        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
