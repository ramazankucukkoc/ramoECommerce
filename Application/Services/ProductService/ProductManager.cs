using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.ProductService
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByName(string name)
        {
            Product? product = await _productRepository.GetAsync(p => p.Name.ToLower() == name.ToLower());
            return product;
        }
    }
}
