using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Interfaces;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Repository
{
    public interface IAddressRepository : IRepository<AddressEntity>
    {
        Task<AddressEntity> SelectAsync(string zipCode);
    }
}
