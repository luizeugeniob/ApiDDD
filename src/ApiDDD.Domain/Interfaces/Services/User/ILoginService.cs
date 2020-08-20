using ApiDDD.Domain.Dtos;
using System.Threading.Tasks;

namespace ApiDDD.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto login);
    }
}
