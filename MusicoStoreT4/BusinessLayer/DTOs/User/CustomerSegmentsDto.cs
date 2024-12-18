using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.User
{
    public class CustomerSegmentsDto
    {
        public required List<CustomerDto> HighValueCustomers { get; set; }
        public required List<CustomerDto> InfrequentCustomers { get; set; }
    }
}
