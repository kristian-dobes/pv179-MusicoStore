using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:MusicoStoreT4/Sahred/DTOs/CategorySummaryDto.cs
namespace Shared.DTOs
========
namespace BusinessLayer.DTOs.Category
>>>>>>>> feature/admin-endpoints:MusicoStoreT4/BusinessLayer/DTOs/Category/CategorySummaryDTO.cs
{
    public class CategorySummaryDTO
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
