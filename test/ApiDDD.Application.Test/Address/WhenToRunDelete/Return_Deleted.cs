using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Interfaces.Services.Address;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.Address.WhenToRunDelete
{
    public class Return_Deleted
    {
        private AddressesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Delete")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Delete()
        {
            var serviceMock = new Mock<IAddressService>();

            serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _controller = new AddressesController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((bool)resultValue);
        }
    }
}
