using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.GiftCard
{
    public class CreateGiftCardDto
    {
        public required decimal DiscountAmount { get; set; }
        public required DateTime ValidityStartDate { get; set; }
        public required DateTime ValidityEndDate { get; set; }
        public required IEnumerable<string> CouponCodes { get; set; }
    }
}
