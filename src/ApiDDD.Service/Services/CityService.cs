using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Interfaces.Services.City;
using ApiDDD.Domain.Models;
using ApiDDD.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Service.Services
{
    public class CityService : ICityService
    {
        private ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CityDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CityDto>(entity);
        }

        public async Task<CityDtoComplete> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<CityDtoComplete>(entity);
        }

        public async Task<CityDtoComplete> GetCompleteByIBGECode(int ibgeCode)
        {
            var entity = await _repository.GetCompleteByIBGECode(ibgeCode);
            return _mapper.Map<CityDtoComplete>(entity);
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CityDto>>(entities);
        }

        public async Task<CityDtoCreateResult> Post(CityDtoCreate city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entity = _mapper.Map<CityEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CityDtoCreateResult>(result);
        }

        public async Task<CityDtoUpdateResult> Put(CityDtoUpdate city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entity = _mapper.Map<CityEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CityDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
