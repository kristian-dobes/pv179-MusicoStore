using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Order;
using DataAccessLayer.Models.Enums;

namespace BusinessLayer.DTOs.User
{
    public class UserDetailDto : UserDto
    {
        public IEnumerable<OrderDto>? Orders { get; set; }
    }
}
