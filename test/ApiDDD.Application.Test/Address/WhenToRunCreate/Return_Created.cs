using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.Address.WhenToRunCreate
{
    public class Return_Created
    {
        private AddressesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Create")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Create()
        {
            var serviceMock = new Mock<IAddressService>();
            serviceMock.Setup(s => s.Post(It.IsAny<AddressDtoCreate>())).ReturnsAsync(
                new AddressDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Street = "Rua Morom",
                    CreatedAt = DateTime.Now
                });

            _controller = new AddressesController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(s => s.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var addressDtoCreate = new AddressDtoCreate
            {
                Street = "Rua Morom"
            };

            var result = await _controller.Post(addressDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as AddressDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(addressDtoCreate.Street, resultValue.Street);
        }
    }
}
