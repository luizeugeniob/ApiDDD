using ApiDDD.Domain.Interfaces.Services.Address;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Address
{
    public class When_To_Run_Post : AddressTests
    {
        private IAddressService _service;
        private Mock<IAddressService> _serviceMock;

        [Fact(DisplayName = "Can Run Post Method")]
        public async Task Can_Run_Post_Method()
        {
            _serviceMock = new Mock<IAddressService>();
            _serviceMock.Setup(m => m.Post(addressDtoCreate)).ReturnsAsync(addressDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(addressDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(AddressZipCode, result.ZipCode);
            Assert.Equal(AddressStreet, result.Street);
            Assert.Equal(AddressNumber, result.Number);
        }
    }
}
