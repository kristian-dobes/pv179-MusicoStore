using BusinessLayer.DTOs.Category;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Category
{
    public class CategoryMergeViewModel
    {
        [Required]
        [Display(Name = "Source Category 1")]
        public int SourceCategoryId1 { get; set; }
        [Required]
        [Display(Name = "Source Category 2")]
        public int SourceCategoryId2 { get; set; }

        [Required]
        [Display(Name = "New Category Name")]
        public string NewCategoryName { get; set; }

        public IEnumerable<CategorySummaryDTO> Categories { get; set; } = [];
    }
}
