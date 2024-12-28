using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Category
{
    public class UpdateCouponCodeDto
    {
        public required int CouponCodeId { get; set; }
        public string Code { get; set; }
        public bool IsUsed { get; set; }
        public int GiftCardId { get; set; }
        public int? OrderId { get; set; }
    }
}
