using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Entities;
using AutoMapper;

namespace ApiDDD.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();

            CreateMap<StateDto, StateEntity>().ReverseMap();

            CreateMap<CityDto, CityEntity>().ReverseMap();
            CreateMap<CityDtoComplete, CityEntity>().ReverseMap();
            CreateMap<CityDtoCreateResult, CityEntity>().ReverseMap();
            CreateMap<CityDtoUpdateResult, CityEntity>().ReverseMap();

            CreateMap<AddressDto, AddressEntity>().ReverseMap();
            CreateMap<AddressDtoCreateResult, AddressEntity>().ReverseMap();
            CreateMap<AddressDtoUpdateResult, AddressEntity>().ReverseMap();
        }
    }
}
