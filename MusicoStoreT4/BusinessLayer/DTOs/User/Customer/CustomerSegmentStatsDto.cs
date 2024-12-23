using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.User.Customer
{
    public class CustomerSegmentStatsDto
    {
        public CustomerDto CustomerDTO { get; set; }
        public decimal TotalExpenditure { get; set; }
        public bool IsInfrequent { get; set; }
    }
}
