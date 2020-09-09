using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiDDD.Service.Test.AutoMapper
{
    public class UserMapper : BaseTest
    {
        [Fact(DisplayName = "Should Be Able To Map The User Models")]
        public void Should_Be_Able_To_Map_The_User_Models()
        {
            var model = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var entities = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                entities.Add(new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }

            // Model -> Entity
            var userEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(userEntity.Id, model.Id);
            Assert.Equal(userEntity.Name, model.Name);
            Assert.Equal(userEntity.Email, model.Email);
            Assert.Equal(userEntity.CreatedAt, model.CreatedAt);
            Assert.Equal(userEntity.UpdatedAt, model.UpdatedAt);

            // Entity -> Dto
            var userDto = Mapper.Map<UserDto>(userEntity);
            Assert.Equal(userDto.Id, userEntity.Id);
            Assert.Equal(userDto.Name, userEntity.Name);
            Assert.Equal(userDto.Email, userEntity.Email);
            Assert.Equal(userDto.CreatedAt, userEntity.CreatedAt);

            // List<Entity> -> List<Dto>
            var dtos = Mapper.Map<List<UserDto>>(entities);
            Assert.True(dtos.Count() == entities.Count());
            for (int i = 0; i < dtos.Count(); i++)
            {
                Assert.Equal(dtos[i].Id, entities[i].Id);
                Assert.Equal(dtos[i].Name, entities[i].Name);
                Assert.Equal(dtos[i].Email, entities[i].Email);
                Assert.Equal(dtos[i].CreatedAt, entities[i].CreatedAt);
            }

            // Entity -> DtoCreateResult
            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(userEntity);
            Assert.Equal(userDtoCreateResult.Id, userEntity.Id);
            Assert.Equal(userDtoCreateResult.Name, userEntity.Name);
            Assert.Equal(userDtoCreateResult.Email, userEntity.Email);
            Assert.Equal(userDtoCreateResult.CreatedAt, userEntity.CreatedAt);

            // Entity -> DtoUpdateResult
            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(userEntity);
            Assert.Equal(userDtoUpdateResult.Id, userEntity.Id);
            Assert.Equal(userDtoUpdateResult.Name, userEntity.Name);
            Assert.Equal(userDtoUpdateResult.Email, userEntity.Email);
            Assert.Equal(userDtoUpdateResult.UpdatedAt, userEntity.UpdatedAt);

            // Dto -> Model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreatedAt, userDto.CreatedAt);

            // Model -> UserDtoCreate
            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            // Model -> UserDtoUpdate
            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
        }
    }
}
