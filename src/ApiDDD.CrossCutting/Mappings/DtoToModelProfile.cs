using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Models;
using AutoMapper;

namespace ApiDDD.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();

            CreateMap<StateModel, StateDto>().ReverseMap();

            CreateMap<CityModel, CityDto>().ReverseMap();
            CreateMap<CityModel, CityDtoCreate>().ReverseMap();
            CreateMap<CityModel, CityDtoUpdate>().ReverseMap();

            CreateMap<AddressModel, AddressDto>().ReverseMap();
            CreateMap<AddressModel, AddressDtoCreate>().ReverseMap();
            CreateMap<AddressModel, AddressDtoUpdate>().ReverseMap();
        }
    }
}
