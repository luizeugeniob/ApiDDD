using ApiDDD.Data.Context;
using ApiDDD.Data.Implementations;
using ApiDDD.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Data.Test
{
    public class StateGets : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public StateGets(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "State Gets")]
        [Trait("GETs", "StateEntity")]
        public async Task Is_Possible_To_Get_States()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                StateImplementation repository = new StateImplementation(context);

                StateEntity entity = new StateEntity
                {
                    Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                    ShortName = "RS",
                    Name = "Rio Grande do Sul"
                };

                var entityExists = await repository.ExistsAsync(entity.Id);
                Assert.True(entityExists);

                var entitySelected = await repository.SelectAsync(entity.Id);
                Assert.NotNull(entitySelected);
                Assert.Equal(entity.ShortName, entitySelected.ShortName);
                Assert.Equal(entity.Name, entitySelected.Name);
                Assert.Equal(entity.Id, entitySelected.Id);

                var entities = await repository.SelectAsync();
                Assert.NotNull(entities);
                Assert.True(entities.Count() == 27);
            }
        }
    }
}
