using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.User.Admin
{
    public class CreateAdminDto
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
    }
}
