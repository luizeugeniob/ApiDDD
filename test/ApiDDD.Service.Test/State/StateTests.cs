using ApiDDD.Domain.Dtos.State;
using System;
using System.Collections.Generic;

namespace ApiDDD.Service.Test.State
{
    public class StateTests
    {
        public static Guid StateId { get; set; }
        public static string Name { get; set; }
        public static string ShortName { get; set; }

        public List<StateDto> stateDtos = new List<StateDto>();
        public StateDto stateDto;

        public StateTests()
        {
            StateId = Guid.NewGuid();
            Name = Faker.Address.UsState();
            ShortName = Faker.Address.UsStateAbbr();

            for (int i = 0; i < 10; i++)
            {
                stateDtos.Add(new StateDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    ShortName = Faker.Address.UsStateAbbr()
                });
            }

            stateDto = new StateDto
            {
                Id = StateId,
                Name = Name,
                ShortName = ShortName
            };
        }
    }
}
