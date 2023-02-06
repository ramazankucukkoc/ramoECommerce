using Application.Features.Categories.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryQuery:IRequest<GetAllCategoryDto>
    {
        public PageRequest PageRequest { get; set; }

        //public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, GetAllCategoryDto>
        //{
        //    private readonly ICategoryRepository _categoryRepository;
        //    private readonly IMapper _mapper;

        //    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        //    {
        //        _categoryRepository = categoryRepository;
        //        _mapper = mapper;
        //    }

        //    public async Task<GetAllCategoryDto> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        //    {
        //        IPaginate<Category> categories = await _categoryRepository.GetListAsync(
        //            index: request.PageRequest.Page, size: request.PageRequest.Page,
        //            include: x => x.Include(x => x.Products).Include(x => x.ParentCategory)
        //            , orderBy: x => x.OrderBy(x => x.Name));



        //    }
        //}
    }
}
