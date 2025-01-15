namespace WebMVC.Models.Shared
{
    public class SearchViewModel
    {
        public string Query { get; set; }
        // public SearchField SearchIn { get; set; }
        public string? Manufacturer { get; set; }
        public string? Category { get; set; }
    }
}