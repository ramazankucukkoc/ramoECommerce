using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public ParentCategory ParentCategory { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }//Unique olacak
        public ICollection<Product> Products { get; set; }

    }
}
