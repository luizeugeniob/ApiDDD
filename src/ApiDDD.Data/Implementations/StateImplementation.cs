using ApiDDD.Data.Context;
using ApiDDD.Data.Repository;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiDDD.Data.Implementations
{
    public class StateImplementation : BaseRepository<StateEntity>, IStateRepository
    {
        private DbSet<StateEntity> _dataSet;

        public StateImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<StateEntity>();
        }
    }
}
