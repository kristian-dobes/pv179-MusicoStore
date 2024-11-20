using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class CustomerSegmentsDto
    {
        public List<CustomerDto> HighValueCustomers { get; set; }
        public List<CustomerDto> InfrequentCustomers { get; set; }
    }
}
