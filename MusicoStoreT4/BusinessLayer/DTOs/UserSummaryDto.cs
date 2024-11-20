using DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class UserSummaryDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public decimal TotalExpenditure { get; set; }
    }
}
