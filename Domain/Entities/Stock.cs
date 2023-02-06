using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Stock:Entity
    {
        public int Quantity { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
