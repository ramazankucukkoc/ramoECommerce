using Application.Features.Baskets.Constants;
using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.Baskets.Rules
{
    public class BasketBusinessRules
    {
        private readonly IBasketRepository _basketRepository;

        public BasketBusinessRules(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task BasketBrandIdControl(int brandId)
        {
            Basket? result = await _basketRepository.GetAsync(b => b.BrandId == brandId);
            if (result == null) throw new BusinessException(BasketBusinessExceptionMessages.BasketBrandIdExists);
        }
        public async Task BasketBrandIdActiveShoulExistsWhenInserted(bool active)
        {
            if (active == false) throw new BusinessException(BusinessRulesExceptionMessages.BrandNotExists);
        }
    }
}
