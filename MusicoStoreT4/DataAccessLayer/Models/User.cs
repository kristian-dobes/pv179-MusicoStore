using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public abstract class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Order>? Orders { get; set; }
    }
}
