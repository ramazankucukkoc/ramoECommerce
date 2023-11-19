using Core.Domain.Entities;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public ParentCategory ParentCategory { get; set; }
       

    }
}
