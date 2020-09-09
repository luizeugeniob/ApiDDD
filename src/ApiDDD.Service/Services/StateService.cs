using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Interfaces.Services.State;
using ApiDDD.Domain.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDDD.Service.Services
{
    public class StateService : IStateService
    {
        private IStateRepository _repository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StateDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<StateDto>(entity);
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            var entities = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<StateDto>>(entities);
        }
    }
}
