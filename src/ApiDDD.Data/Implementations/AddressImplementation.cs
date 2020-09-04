using ApiDDD.Data.Context;
using ApiDDD.Data.Repository;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiDDD.Data.Implementations
{
    public class AddressImplementation : BaseRepository<AddressEntity>, IAddressRepository
    {
        private DbSet<AddressEntity> _dataSet;

        public AddressImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<AddressEntity>();
        }

        public async Task<AddressEntity> SelectAsync(string zipCode)
        {
            return await _dataSet.Include(x => x.City)
                                 .ThenInclude(x => x.State)
                                 .FirstOrDefaultAsync(x => x.ZipCode.Equals(zipCode));
        }
    }
}
