using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Dtos.State;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Address
{
    public class AddressTests
    {
        public static string AddressZipCode { get; set; }
        public static string AddressStreet { get; set; }
        public static string AddressNumber { get; set; }
        public static string AddressZipCodeUpdated { get; set; }
        public static string AddressStreetUpdated { get; set; }
        public static string AddressNumberUpdated { get; set; }
        public static Guid CityId { get; set; }
        public static Guid AddressId { get; set; }

        public List<AddressDto> addressDtos = new List<AddressDto>();
        public AddressDto addressDto;
        public AddressDtoCreate addressDtoCreate;
        public AddressDtoCreateResult addressDtoCreateResult;
        public AddressDtoUpdate addressDtoUpdate;
        public AddressDtoUpdateResult addressDtoUpdateResult;

        public AddressTests()
        {
            CityId = Guid.NewGuid();
            AddressId = Guid.NewGuid();
            AddressZipCode = Faker.RandomNumber.Next(10000, 99999).ToString();
            AddressNumber = Faker.RandomNumber.Next(1, 1000).ToString();
            AddressStreet = Faker.Address.StreetName();
            AddressZipCodeUpdated = Faker.RandomNumber.Next(10000, 99999).ToString();
            AddressNumberUpdated = Faker.RandomNumber.Next(1, 1000).ToString();
            AddressStreetUpdated = Faker.Address.StreetName();

            for (int i = 0; i < 10; i++)
            {
                addressDtos.Add(new AddressDto()
                {
                    Id = Guid.NewGuid(),
                    ZipCode = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    Street = Faker.Address.StreetName(),
                    Number = Faker.RandomNumber.Next(1, 1000).ToString(),
                    CityId = Guid.NewGuid(),
                    City = new CityDtoComplete
                    {
                        Id = CityId,
                        Name = Faker.Address.City(),
                        IBGECode = Faker.RandomNumber.Next(1, 10000),
                        StateId = Guid.NewGuid(),
                        State = new StateDto
                        {
                            Id = Guid.NewGuid(),
                            Name = Faker.Address.UsState(),
                            ShortName = Faker.Address.UsStateAbbr()
                        }
                    }
                });
            }

            addressDto = new AddressDto
            {
                Id = AddressId,
                ZipCode = AddressZipCode,
                Street = AddressStreet,
                Number = AddressNumber,
                CityId = CityId,
                City = new CityDtoComplete
                {
                    Id = CityId,
                    Name = Faker.Address.City(),
                    IBGECode = Faker.RandomNumber.Next(1, 10000),
                    StateId = Guid.NewGuid(),
                    State = new StateDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        ShortName = Faker.Address.UsStateAbbr()
                    }
                }
            };

            addressDtoCreate = new AddressDtoCreate
            {
                ZipCode = AddressZipCode,
                Street = AddressStreet,
                Number = AddressNumber,
                CityId = CityId
            };

            addressDtoCreateResult = new AddressDtoCreateResult
            {
                Id = AddressId,
                ZipCode = AddressZipCode,
                Street = AddressStreet,
                Number = AddressNumber,
                CityId = CityId,
                CreatedAt = DateTime.Now
            };

            addressDtoUpdate = new AddressDtoUpdate
            {
                Id = AddressId,
                ZipCode = AddressZipCodeUpdated,
                Street = AddressStreetUpdated,
                Number = AddressNumberUpdated,
                CityId = CityId,
            };

            addressDtoUpdateResult = new AddressDtoUpdateResult
            {
                Id = CityId,
                ZipCode = AddressZipCodeUpdated,
                Street = AddressStreetUpdated,
                Number = AddressNumberUpdated,
                CityId = CityId,
                UpdatedAt = DateTime.Now
            };

        }
    }
}
