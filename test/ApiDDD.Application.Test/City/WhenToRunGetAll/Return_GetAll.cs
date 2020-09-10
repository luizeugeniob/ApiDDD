using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunGetAll
{
    public class Return_GetAll
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller GetAll")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_GetAll()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(s => s.GetAll()).ReturnsAsync(
                new List<CityDto>
                {
                    new CityDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.City()
                    },
                    new CityDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.City()
                    }
                });

            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<CityDto>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}
