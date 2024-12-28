using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Category
{
    public class CreateCouponCodeDto
    {
        public required string Code { get; set; }
        public required int GiftCardId { get; set; }
    }
}
