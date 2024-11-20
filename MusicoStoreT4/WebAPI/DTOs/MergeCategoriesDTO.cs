namespace WebAPI.DTOs
{
    public class MergeCategoriesDTO
    {
        public string NewCategoryName { get; set; }
        public int SourceCategoryId1 { get; set; }
        public int SourceCategoryId2 { get; set; }
    }
}
