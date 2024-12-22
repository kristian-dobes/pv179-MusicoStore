using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.DTOs.User.Customer;
using DataAccessLayer.Models.Enums;

namespace BusinessLayer.DTOs.User
{
    public class UserDto
    {
        public int? UserId { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public Role Role { get; set; }
        public DateTime? Created { get; set; }
        public CustomerDetailsDto? CustomerDetails { get; set; }
    }
}
