using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Category
{
    public class UpdateGiftCardDto
    {
        public decimal DiscountAmount { get; set; }
        public DateTime? ValidityStartDate { get; set; }
        public DateTime? ValidityEndDate { get; set; }
        public IEnumerable<string>? CouponCodes { get; set; }
    }
}
