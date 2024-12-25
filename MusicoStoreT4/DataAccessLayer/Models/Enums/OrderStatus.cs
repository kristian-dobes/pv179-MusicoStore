using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
