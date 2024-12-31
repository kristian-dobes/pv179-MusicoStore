namespace WebMVC.Models.Product
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDetailViewModel> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
