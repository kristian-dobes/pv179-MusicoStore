using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;
using DataAccessLayer.Models;

namespace BusinessLayer.DTOs.CouponCode
{
    public class CouponCodeDto
    {
        public required int CouponCodeId { get; set; }
        public required DateTime Created { get; set; }
        public required string Code { get; set; }
        public required bool IsUsed { get; set; }
        public required int GiftCardId { get; set; }
        public required int? OrderId { get; set; }
    }
}
