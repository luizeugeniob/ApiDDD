using ApiDDD.Domain.Dtos.Address;
using System;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Interfaces.Services.Address
{
    public interface IAddressService
    {
        Task<AddressDto> Get(Guid id);
        Task<AddressDto> Get(string zipCode);
        Task<AddressDtoCreateResult> Post(AddressDtoCreate user);
        Task<AddressDtoUpdateResult> Put(AddressDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
