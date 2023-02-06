using Application.Features.Stocks.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Stocks.Command.CreateStock
{
    public class CreateStockCommand:IRequest<CreateStockDto>
    {
        public int Quantity { get; set; }

        public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, CreateStockDto>
        {
            private readonly IStockRepository _stockRepository;
            private readonly IMapper _mapper;

            public CreateStockCommandHandler(IStockRepository stockRepository, IMapper mapper)
            {
                _stockRepository = stockRepository;
                _mapper = mapper;
            }

            public async Task<CreateStockDto> Handle(CreateStockCommand request, CancellationToken cancellationToken)
            {
                Stock? mappedStock = _mapper.Map<Stock>(request);
                Stock createdStock = await _stockRepository.AddAsync(mappedStock);
                CreateStockDto createStockDto = _mapper.Map<CreateStockDto>(createdStock);
                return createStockDto;

            }
        }

    }
}
