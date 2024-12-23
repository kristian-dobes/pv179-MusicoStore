using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.DTOs.Category
{
    public class AuditLogDto
    {
        public int ProductId { get; set; }
        public string Action { get; set; }
        public int ModifiedById { get; set; }
    }
}
