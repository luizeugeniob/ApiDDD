using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Repository
{
    public interface ICityRepository : IRepository<CityEntity>
    {
        Task<CityEntity> GetCompleteById(Guid id);
        Task<CityEntity> GetCompleteByIBGECode(int ibgeCode);
    }
}
