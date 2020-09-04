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
    public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UserCrudComplete(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "User Crud")]
        [Trait("CRUD", "UserEntity")]
        public async Task Is_Possible_To_Resolve_User()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation repository = new UserImplementation(context);
                UserEntity entity = new UserEntity()
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var entityCreated = await repository.InsertAsync(entity);
                Assert.NotNull(entityCreated);
                Assert.Equal(entity.Email, entityCreated.Email);
                Assert.Equal(entity.Name, entityCreated.Name);
                Assert.NotNull(entityCreated.CreatedAt);
                Assert.Null(entityCreated.UpdatedAt);
                Assert.False(entityCreated.Id == Guid.Empty);

                entity.Name = Faker.Name.First();
                var entityUpdated = await repository.UpdateAsync(entity);
                Assert.NotNull(entityUpdated);
                Assert.Equal(entity.Email, entityUpdated.Email);
                Assert.Equal(entity.Name, entityUpdated.Name);
                Assert.NotNull(entityUpdated.CreatedAt);
                Assert.NotNull(entityUpdated.UpdatedAt);
                Assert.False(entityUpdated.Id == Guid.Empty);

                var entityExists = await repository.ExistsAsync(entity.Id);
                Assert.True(entityExists);

                var getEntity = await repository.SelectAsync(entity.Id);
                Assert.NotNull(getEntity);
                Assert.Equal(getEntity.Email, entityUpdated.Email);
                Assert.Equal(getEntity.Name, entityUpdated.Name);

                var getAllEntities = await repository.SelectAsync();
                Assert.NotNull(getAllEntities);
                Assert.True(getAllEntities.Count() > 0);

                var isDeleted = await repository.DeleteAsync(getEntity.Id);
                Assert.True(isDeleted);

                var defaultEntity = await repository.FindByLogin("admin@mail.com");
                Assert.NotNull(defaultEntity);
                Assert.Equal("admin@mail.com", defaultEntity.Email);
                Assert.Equal("Admin", defaultEntity.Name);
            }
        }
    }
}
