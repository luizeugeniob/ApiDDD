using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunDelete
{
    public class Return_BadRequest
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Delete")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Delete()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new CitiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido.");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
