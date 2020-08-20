using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Interfaces;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
