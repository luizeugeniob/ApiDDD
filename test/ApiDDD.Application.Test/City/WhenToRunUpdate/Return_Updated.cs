using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunUpdate
{
    public class Return_Updated
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Update")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Update()
        {
            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(s => s.Put(It.IsAny<CityDtoUpdate>())).ReturnsAsync(
                new CityDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "Passo Fundo",
                    UpdatedAt = DateTime.Now
                });

            _controller = new CitiesController(serviceMock.Object);

            var cityDtoUpdate = new CityDtoUpdate
            {
                Name = "Passo Fundo"
            };

            var result = await _controller.Put(cityDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as CityDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(cityDtoUpdate.Name, resultValue.Name);
        }
    }
}
