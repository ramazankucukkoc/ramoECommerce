using Application.Features.Addresss.Command.CreateAddress;
using Application.Features.Addresss.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Addresss.Profiles
{
    public class MappingsProfiles:Profile
    {
        public MappingsProfiles()
        {
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();


        }
    }
}
