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
    public class CityCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CityCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "City Crud")]
        [Trait("CRUD", "CityEntity")]
        public async Task Is_Possible_To_Resolve_City()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CityImplementation repository = new CityImplementation(context);
                CityEntity entity = new CityEntity
                {
                    Name = Faker.Address.City(),
                    IBGECode = Faker.RandomNumber.Next(1000000, 9999999),
                    StateId = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1")
                };

                var entityCreated = await repository.InsertAsync(entity);
                Assert.NotNull(entityCreated);
                Assert.Equal(entity.Name, entityCreated.Name);
                Assert.Equal(entity.IBGECode, entityCreated.IBGECode);
                Assert.NotNull(entityCreated.CreatedAt);
                Assert.Null(entityCreated.UpdatedAt);
                Assert.False(entityCreated.Id == Guid.Empty);

                entity.Name = Faker.Address.City();
                entity.Id = entityCreated.Id;
                var entityUpdated = await repository.UpdateAsync(entity);
                Assert.NotNull(entityUpdated);
                Assert.Equal(entity.Name, entityUpdated.Name);
                Assert.Equal(entity.IBGECode, entityUpdated.IBGECode);
                Assert.NotNull(entityUpdated.CreatedAt);
                Assert.NotNull(entityUpdated.UpdatedAt);
                Assert.False(entityUpdated.Id == Guid.Empty);

                var entityExists = await repository.ExistsAsync(entity.Id);
                Assert.True(entityExists);

                var getEntity = await repository.SelectAsync(entity.Id);
                Assert.NotNull(getEntity);
                Assert.Equal(getEntity.Name, entityUpdated.Name);
                Assert.Equal(getEntity.IBGECode, entityUpdated.IBGECode);
                Assert.Equal(getEntity.StateId, entityUpdated.StateId);
                Assert.Null(getEntity.State);

                var getEntityByIBGE = await repository.GetCompleteByIBGECode(getEntity.IBGECode);
                Assert.NotNull(getEntityByIBGE);
                Assert.Equal(getEntityByIBGE.Name, getEntity.Name);
                Assert.Equal(getEntityByIBGE.IBGECode, getEntity.IBGECode);
                Assert.Equal(getEntityByIBGE.StateId, getEntity.StateId);
                Assert.NotNull(getEntityByIBGE.State);

                var getEntityById = await repository.GetCompleteById(getEntity.Id);
                Assert.NotNull(getEntityById);
                Assert.Equal(getEntityById.Name, getEntity.Name);
                Assert.Equal(getEntityById.IBGECode, getEntity.IBGECode);
                Assert.Equal(getEntityById.StateId, getEntity.StateId);
                Assert.NotNull(getEntityById.State);

                var getAllEntities = await repository.SelectAsync();
                Assert.NotNull(getAllEntities);
                Assert.True(getAllEntities.Count() > 0);

                var isDeleted = await repository.DeleteAsync(getEntity.Id);
                Assert.True(isDeleted);

                getAllEntities = await repository.SelectAsync();
                Assert.NotNull(getAllEntities);
                Assert.True(getAllEntities.Count() == 0);
            }
        }
    }
}
