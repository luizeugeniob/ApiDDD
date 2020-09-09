using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Interfaces.Services.Address;
using ApiDDD.Domain.Models;
using ApiDDD.Domain.Repository;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ApiDDD.Service.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddressDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<AddressDto>(entity);
        }

        public async Task<AddressDto> Get(string zipCode)
        {
            var entity = await _repository.SelectAsync(zipCode);
            return _mapper.Map<AddressDto>(entity);
        }

        public async Task<AddressDtoCreateResult> Post(AddressDtoCreate address)
        {
            var model = _mapper.Map<AddressModel>(address);
            var entity = _mapper.Map<AddressEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<AddressDtoCreateResult>(result);
        }

        public async Task<AddressDtoUpdateResult> Put(AddressDtoUpdate address)
        {
            var model = _mapper.Map<AddressModel>(address);
            var entity = _mapper.Map<AddressEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<AddressDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
