using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiDDD.Service.Test.AutoMapper
{
    public class StateMapper : BaseTest
    {
        [Fact(DisplayName = "Should Be Able To Map The State Models")]
        public void Should_Be_Able_To_Map_The_State_Models()
        {
            var model = new StateModel()
            {
                Id = Guid.NewGuid(),
                ShortName = Faker.Address.UsStateAbbr(),
                Name = Faker.Address.UsState(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var entities = new List<StateEntity>();
            for (int i = 0; i < 5; i++)
            {
                entities.Add(new StateEntity()
                {
                    Id = Guid.NewGuid(),
                    ShortName = Faker.Address.UsStateAbbr(),
                    Name = Faker.Address.UsState(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }

            // Model -> Entity
            var stateEntity = Mapper.Map<StateEntity>(model);
            Assert.Equal(stateEntity.Id, model.Id);
            Assert.Equal(stateEntity.ShortName, model.ShortName);
            Assert.Equal(stateEntity.Name, model.Name);
            Assert.Equal(stateEntity.CreatedAt, model.CreatedAt);
            Assert.Equal(stateEntity.UpdatedAt, model.UpdatedAt);

            // Entity -> Dto
            var stateDto = Mapper.Map<StateDto>(stateEntity);
            Assert.Equal(stateDto.Id, stateEntity.Id);
            Assert.Equal(stateDto.ShortName, stateEntity.ShortName);
            Assert.Equal(stateDto.Name, stateEntity.Name);

            // List<Entity> -> List<Dto>
            var dtos = Mapper.Map<List<StateDto>>(entities);
            Assert.True(dtos.Count() == entities.Count());
            for (int i = 0; i < dtos.Count(); i++)
            {
                Assert.Equal(dtos[i].Id, entities[i].Id);
                Assert.Equal(dtos[i].ShortName, entities[i].ShortName);
                Assert.Equal(dtos[i].Name, entities[i].Name);
            }

            // Dto -> Model
            var stateModel = Mapper.Map<StateModel>(stateDto);
            Assert.Equal(stateModel.Id, stateDto.Id);
            Assert.Equal(stateModel.ShortName, stateDto.ShortName);
            Assert.Equal(stateModel.Name, stateDto.Name);
        }
    }
}
