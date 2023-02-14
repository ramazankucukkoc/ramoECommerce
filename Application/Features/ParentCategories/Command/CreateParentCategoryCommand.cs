using Application.Features.ParentCategories.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ParentCategories.Command
{
    public class CreateParentCategoryCommand : IRequest<CreateParentCategoryDto>
    {
        public string Name { get; set; }

        public class CreateParentCategoryCommandHandler : IRequestHandler<CreateParentCategoryCommand, CreateParentCategoryDto>
        {
            private readonly IParentCategoryRepositories _parentCategoriesRepository;
            private readonly IMapper _mapper;

            public CreateParentCategoryCommandHandler(IParentCategoryRepositories parentCategoriesRepository,
                IMapper mapper)
            {
                _parentCategoriesRepository = parentCategoriesRepository;
                _mapper = mapper;
            }

            public async Task<CreateParentCategoryDto> Handle(CreateParentCategoryCommand request, CancellationToken cancellationToken)
            {
                ParentCategory? mappedParentCategory = _mapper.Map<ParentCategory>(request);
                ParentCategory addedParentCategory = await _parentCategoriesRepository.AddAsync(mappedParentCategory);
                CreateParentCategoryDto createParentCategoryDto = _mapper.Map<CreateParentCategoryDto>(addedParentCategory);
                return createParentCategoryDto;
            }
        }
    }
}
