using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Interfaces.Services.State;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.State.WhenToRunGetAll
{
    public class Return_BadRequest
    {
        private StatesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller GetAll")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_GetAll()
        {
            var serviceMock = new Mock<IStateService>();

            serviceMock.Setup(s => s.GetAll()).ReturnsAsync(
                new List<StateDto>
                {
                    new StateDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        ShortName = Faker.Address.UsStateAbbr()
                    },
                    new StateDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        ShortName = Faker.Address.UsStateAbbr()
                    }
                });

            _controller = new StatesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "FormatoInvalido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
