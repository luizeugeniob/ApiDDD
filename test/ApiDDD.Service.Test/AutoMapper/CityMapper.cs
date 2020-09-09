using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiDDD.Service.Test.AutoMapper
{
    public class CityMapper : BaseTest
    {
        [Fact(DisplayName = "Should Be Able To Map The City Models")]
        public void Should_Be_Able_To_Map_The_City_Models()
        {
            var model = new CityModel()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                IBGECode = Faker.RandomNumber.Next(1, 10000),
                StateId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var entities = new List<CityEntity>();
            for (int i = 0; i < 5; i++)
            {
                entities.Add(new CityEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.City(),
                    IBGECode = Faker.RandomNumber.Next(1, 10000),
                    StateId = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    State = new StateEntity()
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        ShortName = Faker.Address.UsStateAbbr()
                    }
                });
            }

            // Model -> Entity
            var cityEntity = Mapper.Map<CityEntity>(model);
            Assert.Equal(cityEntity.Id, model.Id);
            Assert.Equal(cityEntity.Name, model.Name);
            Assert.Equal(cityEntity.IBGECode, model.IBGECode);
            Assert.Equal(cityEntity.StateId, model.StateId);
            Assert.Equal(cityEntity.CreatedAt, model.CreatedAt);
            Assert.Equal(cityEntity.UpdatedAt, model.UpdatedAt);

            // Entity -> Dto
            var cityDto = Mapper.Map<CityDto>(cityEntity);
            Assert.Equal(cityDto.Id, cityEntity.Id);
            Assert.Equal(cityDto.Name, cityEntity.Name);
            Assert.Equal(cityDto.IBGECode, cityEntity.IBGECode);
            Assert.Equal(cityDto.StateId, cityEntity.StateId);
            
            // Entity -> DtoComplete
            var cityDtoComplete = Mapper.Map<CityDtoComplete>(entities.FirstOrDefault());
            Assert.Equal(cityDtoComplete.Id, entities.FirstOrDefault().Id);
            Assert.Equal(cityDtoComplete.Name, entities.FirstOrDefault().Name);
            Assert.Equal(cityDtoComplete.IBGECode, entities.FirstOrDefault().IBGECode);
            Assert.Equal(cityDtoComplete.StateId, entities.FirstOrDefault().StateId);
            Assert.NotNull(cityDtoComplete.State);

            // List<Entity> -> List<Dto>
            var dtos = Mapper.Map<List<CityDto>>(entities);
            Assert.True(dtos.Count() == entities.Count());
            for (int i = 0; i < dtos.Count(); i++)
            {
                Assert.Equal(dtos[i].Id, entities[i].Id);
                Assert.Equal(dtos[i].Name, entities[i].Name);
                Assert.Equal(dtos[i].IBGECode, entities[i].IBGECode);
                Assert.Equal(dtos[i].StateId, entities[i].StateId);
            }

            // Entity -> DtoCreateResult
            var cityDtoCreateResult = Mapper.Map<CityDtoCreateResult>(cityEntity);
            Assert.Equal(cityDtoCreateResult.Id, cityEntity.Id);
            Assert.Equal(cityDtoCreateResult.Name, cityEntity.Name);
            Assert.Equal(cityDtoCreateResult.IBGECode, cityEntity.IBGECode);
            Assert.Equal(cityDtoCreateResult.StateId, cityEntity.StateId);
            Assert.Equal(cityDtoCreateResult.CreatedAt, cityEntity.CreatedAt);

            // Entity -> DtoUpdateResult
            var cityDtoUpdateResult = Mapper.Map<CityDtoUpdateResult>(cityEntity);
            Assert.Equal(cityDtoUpdateResult.Id, cityEntity.Id);
            Assert.Equal(cityDtoUpdateResult.Name, cityEntity.Name);
            Assert.Equal(cityDtoUpdateResult.IBGECode, cityEntity.IBGECode);
            Assert.Equal(cityDtoUpdateResult.StateId, cityEntity.StateId);
            Assert.Equal(cityDtoUpdateResult.UpdatedAt, cityEntity.UpdatedAt);

            // Dto -> Model
            var cityModel = Mapper.Map<CityModel>(cityDto);
            Assert.Equal(cityModel.Id, cityDto.Id);
            Assert.Equal(cityModel.Name, cityDto.Name);
            Assert.Equal(cityModel.IBGECode, cityDto.IBGECode);
            Assert.Equal(cityModel.StateId, cityDto.StateId);

            // Model -> UserDtoCreate
            var cityDtoCreate = Mapper.Map<CityDtoCreate>(cityModel);
            Assert.Equal(cityDtoCreate.Name, cityModel.Name);
            Assert.Equal(cityDtoCreate.IBGECode, cityModel.IBGECode);
            Assert.Equal(cityDtoCreate.StateId, cityModel.StateId);

            // Model -> UserDtoUpdate
            var cityDtoUpdate = Mapper.Map<CityDtoUpdate>(cityModel);
            Assert.Equal(cityDtoUpdate.Id, cityModel.Id);
            Assert.Equal(cityDtoUpdate.Name, cityModel.Name);
            Assert.Equal(cityDtoUpdate.IBGECode, cityModel.IBGECode);
            Assert.Equal(cityDtoUpdate.StateId, cityModel.StateId);
        }
    }
}
