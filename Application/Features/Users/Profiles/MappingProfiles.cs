using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserListDto>()
                .ForMember(x => x.OperationClaims, opt => opt.MapFrom(x => x.UserOperationClaims.Select(x => x.OperationClaim))).ReverseMap();
                
            CreateMap<IPaginate<User>,GetListResponse<UserListDto>>().ReverseMap();
        }

    }
}
