using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.DTOs.Category
{
    public class GiftCardDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ValidityStartDate { get; set; }
        public DateTime ValidityEndDate { get; set; }
        public IEnumerable<CouponCodeDto> CouponCodes { get; set; }
    }
}
