using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunCreate
{
    public class Return_Created
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Create")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Create()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(s => s.Post(It.IsAny<CityDtoCreate>())).ReturnsAsync(
                new CityDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "Passo Fundo",
                    CreatedAt = DateTime.Now
                });

            _controller = new CitiesController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(s => s.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cityDtoCreate = new CityDtoCreate
            {
                Name = "Passo Fundo"
            };

            var result = await _controller.Post(cityDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CityDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(cityDtoCreate.Name, resultValue.Name);
        }
    }
}
