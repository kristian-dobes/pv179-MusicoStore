using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
