using Domain.Entities;

namespace Application.Services.ProductService
{
    public interface IProductService
    {
        Task<Product> GetByName(string name);
        Task<Product> GetById(int id);
    }
}
