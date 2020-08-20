using ApiDDD.Data.Context;
using ApiDDD.Data.Repository;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiDDD.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataSet;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataSet.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}
