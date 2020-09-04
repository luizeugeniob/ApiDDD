using ApiDDD.Data.Context;
using ApiDDD.Data.Implementations;
using ApiDDD.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Data.Test
{
    public class AddressCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public AddressCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Address Crud")]
        [Trait("CRUD", "AddressEntity")]
        public async Task Is_Possible_To_Resolve_City()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CityImplementation cityRepository = new CityImplementation(context);
                CityEntity city = new CityEntity
                {
                    Name = Faker.Address.City(),
                    IBGECode = Faker.RandomNumber.Next(1000000, 9999999),
                    StateId = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1")
                };

                var cityCreated = await cityRepository.InsertAsync(city);
                Assert.NotNull(cityCreated);
                Assert.Equal(city.Name, cityCreated.Name);
                Assert.Equal(city.IBGECode, cityCreated.IBGECode);
                Assert.NotNull(cityCreated.CreatedAt);
                Assert.Null(cityCreated.UpdatedAt);
                Assert.False(cityCreated.Id == Guid.Empty);

                AddressImplementation repository = new AddressImplementation(context);
                AddressEntity entity = new AddressEntity
                {
                    ZipCode = "99.010-030",
                    Street = Faker.Address.StreetName(),
                    Number = "930",
                    CityId = city.Id
                };

                var entityCreated = await repository.InsertAsync(entity);
                Assert.NotNull(entityCreated);
                Assert.Equal(entity.ZipCode, entityCreated.ZipCode);
                Assert.Equal(entity.Street, entityCreated.Street);
                Assert.Equal(entity.Number, entityCreated.Number);
                Assert.Equal(entity.CityId, entityCreated.CityId);
                Assert.NotNull(entityCreated.CreatedAt);
                Assert.Null(entityCreated.UpdatedAt);
                Assert.False(entityCreated.Id == Guid.Empty);

                entity.Street = Faker.Address.StreetName();
                entity.Id = entityCreated.Id;
                var entityUpdated = await repository.UpdateAsync(entity);
                Assert.NotNull(entityUpdated);
                Assert.Equal(entity.ZipCode, entityUpdated.ZipCode);
                Assert.Equal(entity.Street, entityUpdated.Street);
                Assert.Equal(entity.Number, entityUpdated.Number);
                Assert.Equal(entity.CityId, entityUpdated.CityId);
                Assert.NotNull(entityUpdated.CreatedAt);
                Assert.NotNull(entityUpdated.UpdatedAt);
                Assert.False(entityUpdated.Id == Guid.Empty);

                var entityExists = await repository.ExistsAsync(entity.Id);
                Assert.True(entityExists);

                var getEntity = await repository.SelectAsync(entity.Id);
                Assert.NotNull(getEntity);
                Assert.Equal(getEntity.ZipCode, entityUpdated.ZipCode);
                Assert.Equal(getEntity.Street, entityUpdated.Street);
                Assert.Equal(getEntity.Number, entityUpdated.Number);
                Assert.Equal(getEntity.CityId, entityUpdated.CityId);

                getEntity = await repository.SelectAsync(entity.ZipCode);
                Assert.NotNull(getEntity);
                Assert.Equal(getEntity.ZipCode, entityUpdated.ZipCode);
                Assert.Equal(getEntity.Street, entityUpdated.Street);
                Assert.Equal(getEntity.Number, entityUpdated.Number);
                Assert.Equal(getEntity.CityId, entityUpdated.CityId);
                Assert.NotNull(getEntity.City);
                Assert.Equal(city.Name, getEntity.City.Name);
                Assert.NotNull(getEntity.City.State);
                Assert.Equal("RS", getEntity.City.State.ShortName);

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
