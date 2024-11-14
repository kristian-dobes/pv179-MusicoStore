using DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
