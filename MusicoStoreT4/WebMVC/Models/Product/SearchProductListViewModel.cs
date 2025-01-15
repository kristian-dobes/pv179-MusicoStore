using WebMVC.Models.Category;
using WebMVC.Models.Manufacturer;
using WebMVC.Models.Shared;

namespace WebMVC.Models.Product
{
    public class SearchProductListViewModel : ProductListViewModel
    {
        public SearchViewModel SearchParams { get; set; }
        public IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
