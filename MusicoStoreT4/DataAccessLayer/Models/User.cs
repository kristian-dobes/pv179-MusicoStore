using DataAccessLayer.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        public virtual IEnumerable<Order>? Orders { get; set; }
        public Role Role { get; set; }
    }
}
