using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.Products.Rules
{
    public class ProductBusinnessRules : BaseBusinessRules
    {
        private readonly IProductRepository _productRepository;
        public ProductBusinnessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ProductCanNotBeDuplicatedWhenInserted(int id)
        {
            Product? product = await _productRepository.GetAsync(c => c.Id == id);
            if (product is null) throw new BusinessException(ProductExceptionMessages.ProductIsNotExists);
        }
        public async void CheckIfProductNameExists(string productName)
        {
            Product? checkProductName = await _productRepository.GetAsync(p => p.Name.ToLower().Trim() == productName.ToLower().Trim());
            if (checkProductName is not null) throw new BusinessException(ProductExceptionMessages.ProductNameExists);
        }
    }
}
