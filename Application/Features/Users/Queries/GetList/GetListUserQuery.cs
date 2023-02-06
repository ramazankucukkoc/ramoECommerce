using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<GetListResponse<UserListDto>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, GetListResponse<UserListDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            //Dependency Injection aynısı.
            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            => (_userRepository, _mapper) = (userRepository, mapper);

            public async Task<GetListResponse<UserListDto>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(
                    include: x => x.Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                GetListResponse<UserListDto> response = _mapper.Map<GetListResponse<UserListDto>>(users);
                return response;

            }
        }
    }
}
