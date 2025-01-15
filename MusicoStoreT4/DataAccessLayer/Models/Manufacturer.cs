namespace DataAccessLayer.Models
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
