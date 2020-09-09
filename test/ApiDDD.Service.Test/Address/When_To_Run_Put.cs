using ApiDDD.Domain.Interfaces.Services.Address;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Address
{
    public class When_To_Run_Put : AddressTests
    {
        private IAddressService _service;
        private Mock<IAddressService> _serviceMock;

        [Fact(DisplayName = "Can Run Put Method")]
        public async Task Can_Run_Put_Method()
        {
            _serviceMock = new Mock<IAddressService>();
            _serviceMock.Setup(m => m.Put(addressDtoUpdate)).ReturnsAsync(addressDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(addressDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(AddressZipCodeUpdated, resultUpdate.ZipCode);
            Assert.Equal(AddressStreetUpdated, resultUpdate.Street);
            Assert.Equal(AddressNumberUpdated, resultUpdate.Number);
        }
    }
}
