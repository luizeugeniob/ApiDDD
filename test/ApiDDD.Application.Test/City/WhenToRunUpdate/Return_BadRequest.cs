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
    public class Return_BadRequest
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
                    Name = Faker.Address.City(),
                    UpdatedAt = DateTime.Now
                });

            _controller = new CitiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Nome é obrigatório.");

            var cityDtoUpdate = new CityDtoUpdate
            {
                Name = Faker.Address.City(),
                IBGECode = 1
            };

            var result = await _controller.Put(cityDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
