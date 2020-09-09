using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Entities;
using ApiDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiDDD.Service.Test.AutoMapper
{
    public class AddressMapper : BaseTest
    {
        [Fact(DisplayName = "Should Be Able To Map The Address Models")]
        public void Should_Be_Able_To_Map_The_Address_Models()
        {
            var model = new AddressModel()
            {
                Id = Guid.NewGuid(),
                ZipCode = Faker.RandomNumber.Next(1, 10000).ToString(),
                Street = Faker.Address.StreetAddress(),
                Number = "",
                CityId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var entities = new List<AddressEntity>();
            for (int i = 0; i < 5; i++)
            {
                entities.Add(new AddressEntity()
                {
                    Id = Guid.NewGuid(),
                    ZipCode = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Street = Faker.Address.StreetAddress(),
                    Number = Faker.RandomNumber.Next(1, 10000).ToString(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CityId = Guid.NewGuid(),
                    City = new CityEntity()
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.City(),
                        IBGECode = Faker.RandomNumber.Next(1, 10000),
                        StateId = Guid.NewGuid(),
                        State = new StateEntity()
                        {
                            Id = Guid.NewGuid(),
                            Name = Faker.Address.UsState(),
                            ShortName = Faker.Address.UsStateAbbr()
                        }
                    }
                });
            }

            // Model -> Entity
            var addressEntity = Mapper.Map<AddressEntity>(model);
            Assert.Equal(addressEntity.Id, model.Id);
            Assert.Equal(addressEntity.Street, model.Street);
            Assert.Equal(addressEntity.Number, model.Number);
            Assert.Equal(addressEntity.ZipCode, model.ZipCode);
            Assert.Equal(addressEntity.CreatedAt, model.CreatedAt);
            Assert.Equal(addressEntity.UpdatedAt, model.UpdatedAt);

            // Entity -> Dto
            var addressDto = Mapper.Map<AddressDto>(addressEntity);
            Assert.Equal(addressDto.Id, addressEntity.Id);
            Assert.Equal(addressDto.Street, addressEntity.Street);
            Assert.Equal(addressDto.Number, addressEntity.Number);
            Assert.Equal(addressDto.ZipCode, addressEntity.ZipCode);
            
            // Entity -> DtoComplete
            var addressDtoComplete = Mapper.Map<AddressDto>(entities.FirstOrDefault());
            Assert.Equal(addressDtoComplete.Id, entities.FirstOrDefault().Id);
            Assert.Equal(addressDtoComplete.ZipCode, entities.FirstOrDefault().ZipCode);
            Assert.Equal(addressDtoComplete.Street, entities.FirstOrDefault().Street);
            Assert.Equal(addressDtoComplete.Number, entities.FirstOrDefault().Number);
            Assert.NotNull(addressDtoComplete.City);
            Assert.NotNull(addressDtoComplete.City.State);

            // List<Entity> -> List<Dto>
            var dtos = Mapper.Map<List<AddressDto>>(entities);
            Assert.True(dtos.Count() == entities.Count());
            for (int i = 0; i < dtos.Count(); i++)
            {
                Assert.Equal(dtos[i].Id, entities[i].Id);
                Assert.Equal(dtos[i].ZipCode, entities[i].ZipCode);
                Assert.Equal(dtos[i].Street, entities[i].Street);
                Assert.Equal(dtos[i].Number, entities[i].Number);
                Assert.Equal(dtos[i].CityId, entities[i].CityId);
            }

            // Entity -> DtoCreateResult
            var addressDtoCreateResult = Mapper.Map<AddressDtoCreateResult>(addressEntity);
            Assert.Equal(addressDtoCreateResult.Id, addressEntity.Id);
            Assert.Equal(addressDtoCreateResult.ZipCode, addressEntity.ZipCode);
            Assert.Equal(addressDtoCreateResult.Street, addressEntity.Street);
            Assert.Equal(addressDtoCreateResult.Number, addressEntity.Number);
            Assert.Equal(addressDtoCreateResult.CityId, addressEntity.CityId);
            Assert.Equal(addressDtoCreateResult.CreatedAt, addressEntity.CreatedAt);

            // Entity -> DtoUpdateResult
            var addressDtoUpdateResult = Mapper.Map<AddressDtoUpdateResult>(addressEntity);
            Assert.Equal(addressDtoUpdateResult.Id, addressEntity.Id);
            Assert.Equal(addressDtoUpdateResult.ZipCode, addressEntity.ZipCode);
            Assert.Equal(addressDtoUpdateResult.Street, addressEntity.Street);
            Assert.Equal(addressDtoUpdateResult.Number, addressEntity.Number);
            Assert.Equal(addressDtoUpdateResult.CityId, addressEntity.CityId);
            Assert.Equal(addressDtoUpdateResult.UpdatedAt, addressEntity.UpdatedAt);

            // Dto -> Model
            addressDto.Number = string.Empty;
            var addressModel = Mapper.Map<AddressModel>(addressDto);
            Assert.Equal(addressModel.Id, addressDto.Id);
            Assert.Equal(addressModel.ZipCode, addressDto.ZipCode);
            Assert.Equal(addressModel.Street, addressDto.Street);
            Assert.Equal("S/N", addressModel.Number);
            Assert.Equal(addressModel.CityId, addressDto.CityId);

            // Model -> UserDtoCreate
            var addressDtoCreate = Mapper.Map<AddressDtoCreate>(addressModel);
            Assert.Equal(addressDtoCreate.ZipCode, addressModel.ZipCode);
            Assert.Equal(addressDtoCreate.Street, addressModel.Street);
            Assert.Equal(addressDtoCreate.Number, addressModel.Number);
            Assert.Equal(addressDtoCreate.CityId, addressModel.CityId);

            // Model -> UserDtoUpdate
            var addressDtoUpdate = Mapper.Map<AddressDtoUpdate>(addressModel);
            Assert.Equal(addressDtoUpdate.Id, addressModel.Id);
            Assert.Equal(addressDtoUpdate.ZipCode, addressModel.ZipCode);
            Assert.Equal(addressDtoUpdate.Street, addressModel.Street);
            Assert.Equal(addressDtoUpdate.Number, addressModel.Number);
            Assert.Equal(addressDtoUpdate.CityId, addressModel.CityId);
        }
    }
}
