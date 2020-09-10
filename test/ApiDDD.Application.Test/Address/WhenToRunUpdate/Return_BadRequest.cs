using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.Address.WhenToRunUpdate
{
    public class Return_BadRequest
    {
        private AddressesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Update")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Update()
        {
            var serviceMock = new Mock<IAddressService>();
            serviceMock.Setup(s => s.Put(It.IsAny<AddressDtoUpdate>())).ReturnsAsync(
                new AddressDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Street = "Rua Morom",
                    UpdatedAt = DateTime.Now
                });

            _controller = new AddressesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Street", "Logradouro é obrigatório.");

            var addressDtoUpdate = new AddressDtoUpdate
            {
                Id = Guid.NewGuid(),
                Street = "Rua Morom"
            };

            var result = await _controller.Put(addressDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
