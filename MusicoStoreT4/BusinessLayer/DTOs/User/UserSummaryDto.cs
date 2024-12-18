using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models.Enums;

namespace BusinessLayer.DTOs.User
{
    public class UserSummaryDto
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public Role Role { get; set; }
        public decimal TotalExpenditure { get; set; }
    }
}
