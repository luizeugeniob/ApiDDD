using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Dtos.State;
using System;
using System.Collections.Generic;

namespace ApiDDD.Service.Test.City
{
    public class CityTests
    {
        public static string CityName { get; set; }
        public static int CityIBGECode { get; set; }
        public static string CityNameUpdated { get; set; }
        public static int CityIBGECodeUpdated { get; set; }
        public static Guid CityId { get; set; }
        public static Guid StateId { get; set; }

        public List<CityDto> cityDtos = new List<CityDto>();
        public CityDto cityDto;
        public CityDtoComplete cityDtoComplete;
        public CityDtoCreate cityDtoCreate;
        public CityDtoCreateResult cityDtoCreateResult;
        public CityDtoUpdate cityDtoUpdate;
        public CityDtoUpdateResult cityDtoUpdateResult;

        public CityTests()
        {
            CityId = Guid.NewGuid();
            CityName = Faker.Address.StreetName();
            CityIBGECode = Faker.RandomNumber.Next(1, 10000);
            CityNameUpdated = Faker.Address.StreetName();
            CityIBGECodeUpdated = Faker.RandomNumber.Next(1, 10000);
            StateId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                cityDtos.Add(new CityDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    IBGECode = Faker.RandomNumber.Next(1, 10000),
                    StateId = Guid.NewGuid()
                });
            }

            cityDto = new CityDto
            {
                Id = CityId,
                Name = CityName,
                IBGECode = CityIBGECode,
                StateId = StateId
            };

            cityDtoComplete = new CityDtoComplete
            {
                Id = CityId,
                Name = CityName,
                IBGECode = CityIBGECode,
                StateId = StateId,
                State = new StateDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    ShortName = Faker.Address.UsStateAbbr()
                }
            };

            cityDtoCreate = new CityDtoCreate
            {
                Name = CityName,
                IBGECode = CityIBGECode,
                StateId = StateId
            };

            cityDtoCreateResult = new CityDtoCreateResult
            {
                Id = CityId,
                Name = CityName,
                IBGECode = CityIBGECode,
                StateId = StateId,
                CreatedAt = DateTime.Now
            };

            cityDtoUpdate = new CityDtoUpdate
            {
                Id = CityId,
                Name = CityNameUpdated,
                IBGECode = CityIBGECodeUpdated,
                StateId = StateId
            };

            cityDtoUpdateResult = new CityDtoUpdateResult
            {
                Id = CityId,
                Name = CityNameUpdated,
                IBGECode = CityIBGECodeUpdated,
                StateId = StateId,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
