using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Rules;
using Application.Services.BrandService;
using Application.Services.ProductService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Command.UpdateBasket
{
    public class UpdateBasketCommand : IRequest<UpdateBasketDto>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int Count { get; set; }
        public int UserId { get; set; }

        public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, UpdateBasketDto>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;
            private readonly BasketBusinessRules _basketBusinessRules;
            private readonly IProductService _productService;
            private readonly IBrandService _brandService;

            public UpdateBasketCommandHandler(IBasketRepository basketRepository, 
                IMapper mapper, BasketBusinessRules basketBusinessRules, IProductService productService, IBrandService brandService)
            =>
                (_basketRepository, _mapper, _basketBusinessRules, _productService, _brandService)
                = (basketRepository, mapper, basketBusinessRules, _productService, brandService);
            public async Task<UpdateBasketDto> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                Product product = await _productService.GetByName(request.ProductName);
                await _basketBusinessRules.ProductControl(product.Id);
                Brand brand = await _brandService.GetByName(request.BrandName);
                await _basketBusinessRules.BrandControl(brand.Id);
                await _basketBusinessRules.BasketIdControl(request.Id);
                Basket? basket = await _basketRepository.GetAsync(b => b.Id == request.Id);
                basket.BrandId = brand.Id;
                basket.ProductId = product.Id;
                basket.Count = request.Count;
                UpdateBasketDto updateBasketDto = _mapper.Map<UpdateBasketDto>(basket);
                return updateBasketDto;
            }
        }
    }
}
