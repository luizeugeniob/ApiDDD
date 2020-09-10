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
    public class Return_Get
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

            var result = await _controller.Get("99.010-030");
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as AddressDto;
            Assert.NotNull(resultValue);
            Assert.Equal("Rua Morom", resultValue.Street);
        }
    }
}
