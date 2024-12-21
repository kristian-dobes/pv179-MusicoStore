using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.User
{
    public class CustomerSegmentStatsDto
    {
        public Customer Customer { get; set; }
        public decimal TotalExpenditure { get; set; }
        public bool IsInfrequent { get; set; }
    }
}
