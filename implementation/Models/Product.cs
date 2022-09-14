using implementation.Models.Abstractions;

namespace implementation.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}