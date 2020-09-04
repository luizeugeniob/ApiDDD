using ApiDDD.Domain.Dtos.City;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Interfaces.Services.City
{
    public interface ICityService
    {
        Task<CityDto> Get(Guid id);
        Task<CityDtoComplete> GetCompleteById(Guid id);
        Task<CityDtoComplete> GetCompleteByIBGECode(Guid id);
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDtoCreateResult> Post(CityDtoCreate user);
        Task<CityDtoUpdateResult> Put(CityDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
