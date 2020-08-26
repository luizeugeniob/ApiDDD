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

                var userCreated = await repository.InsertAsync(entity);
                Assert.NotNull(userCreated);
                Assert.Equal(entity.Email, userCreated.Email);
                Assert.Equal(entity.Name, userCreated.Name);
                Assert.NotNull(userCreated.CreatedAt);
                Assert.Null(userCreated.UpdatedAt);
                Assert.False(userCreated.Id == Guid.Empty);

                entity.Name = Faker.Name.First();
                var userUpdated = await repository.UpdateAsync(entity);
                Assert.NotNull(userUpdated);
                Assert.Equal(entity.Email, userUpdated.Email);
                Assert.Equal(entity.Name, userUpdated.Name);
                Assert.NotNull(userCreated.CreatedAt);
                Assert.NotNull(userCreated.UpdatedAt);
                Assert.False(userCreated.Id == Guid.Empty);

                var userExists = await repository.ExistsAsync(entity.Id);
                Assert.True(userExists);

                var getUser = await repository.SelectAsync(entity.Id);
                Assert.NotNull(getUser);
                Assert.Equal(getUser.Email, userUpdated.Email);
                Assert.Equal(getUser.Name, userUpdated.Name);

                var getAllUsers = await repository.SelectAsync();
                Assert.NotNull(getAllUsers);
                Assert.True(getAllUsers.Count() > 0);

                var isDeleted = await repository.DeleteAsync(getUser.Id);
                Assert.True(isDeleted);

                var defaultUser = await repository.FindByLogin("admin@mail.com");
                Assert.NotNull(defaultUser);
                Assert.Equal("admin@mail.com", defaultUser.Email);
                Assert.Equal("Admin", defaultUser.Name);
            }
        }
    }
}
