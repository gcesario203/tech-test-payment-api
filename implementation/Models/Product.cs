using implementation.Models.Abstractions;

namespace implementation.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public Product(int id, string name, decimal price) : base(id)
        {
            Name = name;
            Price = price;
        }
    }
}