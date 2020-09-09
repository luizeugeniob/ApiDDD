using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Models;
using AutoMapper;

namespace ApiDDD.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<StateEntity, StateModel>().ReverseMap();
            CreateMap<CityEntity, CityModel>().ReverseMap();
            CreateMap<AddressEntity, AddressModel>().ReverseMap();
        }
    }
}
