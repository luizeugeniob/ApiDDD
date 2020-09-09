using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Interfaces.Services.Address;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Address
{
    public class When_To_Run_Get : AddressTests
    {
        private IAddressService _service;
        private Mock<IAddressService> _serviceMock;

        [Fact(DisplayName = "Can Run Get Method")]
        public async Task Can_Run_Get_Method()
        {
            _serviceMock = new Mock<IAddressService>();
            _serviceMock.Setup(m => m.Get(AddressId)).ReturnsAsync(addressDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(AddressId);
            Assert.NotNull(result);
            Assert.True(result.Id == AddressId);
            Assert.Equal(AddressZipCode, result.ZipCode);
            Assert.Equal(AddressStreet, result.Street);

            _serviceMock = new Mock<IAddressService>();
            _serviceMock.Setup(m => m.Get(AddressZipCode)).ReturnsAsync(addressDto);
            _service = _serviceMock.Object;

            result = await _service.Get(AddressZipCode);
            Assert.NotNull(result);
            Assert.True(result.Id == AddressId);
            Assert.Equal(AddressZipCode, result.ZipCode);
            Assert.Equal(AddressStreet, result.Street);

            _serviceMock = new Mock<IAddressService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((AddressDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
