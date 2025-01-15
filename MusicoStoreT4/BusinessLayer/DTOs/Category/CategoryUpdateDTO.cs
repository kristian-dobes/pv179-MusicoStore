using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs.Category
{
    public class CategoryUpdateDTO
    {
        [MinLength(1)]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
