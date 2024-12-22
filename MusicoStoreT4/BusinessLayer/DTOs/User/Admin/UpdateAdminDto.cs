using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.User
{
    public class UpdateAdminDto
    {
        public required int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}
