using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunGetCompleteById
{
    public class Return_BadRequest
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller GetCompleteById")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_GetCompleteById()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(s => s.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(
                new CityDtoComplete
                {
                    Id = Guid.NewGuid(),
                    Name = "Passo Fundo"
                });

            _controller = new CitiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido.");

            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
