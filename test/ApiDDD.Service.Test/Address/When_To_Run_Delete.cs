using ApiDDD.Domain.Interfaces.Services.Address;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Address
{
    public class When_To_Run_Delete : AddressTests
    {
        private IAddressService _service;
        private Mock<IAddressService> _serviceMock;
        [Fact(DisplayName = "Can Run Delete Method")]
        public async Task Can_Run_Delete_Method()
        {
            _serviceMock = new Mock<IAddressService>();
            _serviceMock.Setup(m => m.Delete(AddressId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(AddressId);
            Assert.True(deletado);

            _serviceMock = new Mock<IAddressService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
