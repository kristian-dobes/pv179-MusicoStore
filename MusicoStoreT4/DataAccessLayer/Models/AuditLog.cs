using DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AuditLog : BaseEntity
    {
        public int ProductId { get; set; }
        public AuditAction Action { get; set; }
        public int ModifiedById { get; set; }
    }
}
