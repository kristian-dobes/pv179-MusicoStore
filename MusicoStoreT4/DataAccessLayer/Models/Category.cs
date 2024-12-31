namespace DataAccessLayer.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product>? PrimaryProducts { get; set; } = new List<Product>();
        public virtual ICollection<Product>? SecondaryProducts { get; set; } = new List<Product>();
    }
}
