using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Interfaces.Services.State;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.State.WhenToRunGet
{
    public class Return_BadRequest
    {
        private StatesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Get")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Get()
        {
            var serviceMock = new Mock<IStateService>();

            serviceMock.Setup(s => s.Get(It.IsAny<Guid>())).ReturnsAsync(
                new StateDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Rio Grande do Sul",
                    ShortName = "RS"                    
                });

            _controller = new StatesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido.");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
