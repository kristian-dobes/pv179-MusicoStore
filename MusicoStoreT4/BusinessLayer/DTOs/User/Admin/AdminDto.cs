using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.User.Admin
{
    public class AdminDto
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
    }
}
