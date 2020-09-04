using ApiDDD.Data.Context;
using ApiDDD.Data.Repository;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApiDDD.Data.Implementations
{
    public class CityImplementation : BaseRepository<CityEntity>, ICityRepository
    {
        private DbSet<CityEntity> _dataSet;

        public CityImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<CityEntity>();
        }

        public async Task<CityEntity> GetCompleteByIBGECode(int ibgeCode)
        {
            return await _dataSet.Include(x => x.State)
                                 .FirstOrDefaultAsync(x => x.IBGECode.Equals(ibgeCode));
        }

        public async Task<CityEntity> GetCompleteById(Guid id)
        {
            return await _dataSet.Include(x => x.State)
                                 .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
