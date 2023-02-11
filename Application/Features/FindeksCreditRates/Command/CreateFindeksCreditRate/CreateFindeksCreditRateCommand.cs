using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Command.CreateFindeksCreditRate
{
    public class CreateFindeksCreditRateCommand:IRequest<CreateFindeksCreditRateDto>
    {
        public int CustomerId { get; set; }
        public int Score { get; set; }

        public class CreateFindeksCreditRateCommandHandler : IRequestHandler<CreateFindeksCreditRateCommand, CreateFindeksCreditRateDto>
        {
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IMapper _mapper;
            private readonly FindeksCreditRateBusinessRules _fadeksCreditRateBusinessRules;

            public CreateFindeksCreditRateCommandHandler(IFindeksCreditRateRepository findeksCreditRateRepository,
                IMapper mapper, FindeksCreditRateBusinessRules fadeksCreditRateBusinessRules)
            {
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _mapper = mapper;
                _fadeksCreditRateBusinessRules = fadeksCreditRateBusinessRules;
            }

            public async Task<CreateFindeksCreditRateDto> Handle(CreateFindeksCreditRateCommand request, CancellationToken cancellationToken)
            {
                FindeksCreditRate mappedFindeksCreditRate = _mapper.Map<FindeksCreditRate>(request);
                FindeksCreditRate createdFindeksCredidRate =await _findeksCreditRateRepository.AddAsync(mappedFindeksCreditRate);
                CreateFindeksCreditRateDto result =_mapper.Map<CreateFindeksCreditRateDto>(createdFindeksCredidRate);
                return result;
            }

        }
    }
}
