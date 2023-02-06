using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Baskets.Command.CreateBasket
{
    public class CreateBasketCommand:IRequest<CreateBasketDto>
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }

        public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, CreateBasketDto>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly  IMapper _mapper;
            private readonly BasketBusinessRules _basketBusinessRules;

            public CreateBasketCommandHandler(IBasketRepository basketRepository, 
                IMapper mapper, BasketBusinessRules basketBusinessRules)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
                _basketBusinessRules = basketBusinessRules;
            }

            public async Task<CreateBasketDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
            {
                Basket? mappedBasket = _mapper.Map<Basket>(request);
                Basket createBasket = await _basketRepository.AddAsync(mappedBasket);
                CreateBasketDto createBasketDto = _mapper.Map<CreateBasketDto>(createBasket);
                return createBasketDto;
            }
        }
    }
}
