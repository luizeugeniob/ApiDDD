using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.Address.WhenToRunGetByZipCode
{
    public class Return_BadRequest
    {
        private AddressesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller GetByZipCode")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_GetByZipCode()
        {
            var serviceMock = new Mock<IAddressService>();
            serviceMock.Setup(s => s.Get(It.IsAny<string>())).ReturnsAsync(
                new AddressDto
                {
                    Id = Guid.NewGuid(),
                    Street = "Rua Morom"
                });

            _controller = new AddressesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Street", "Logradouro é obrigatório.");

            var result = await _controller.Get("99.010-030");
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
