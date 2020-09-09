using ApiDDD.Domain.Interfaces.Services.City;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.City
{
    public class When_To_Run_Put : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Can Run Put Method")]
        public async Task Can_Run_Put_Method()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.Post(cityDtoCreate)).ReturnsAsync(cityDtoCreateResult);
            _service = _serviceMock.Object;

            var cityCreated = await _service.Post(cityDtoCreate);
            Assert.NotNull(cityCreated);
            Assert.Equal(CityName, cityCreated.Name);
            Assert.Equal(CityIBGECode, cityCreated.IBGECode);
            Assert.Equal(StateId, cityCreated.StateId);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.Put(cityDtoUpdate)).ReturnsAsync(cityDtoUpdateResult);
            _service = _serviceMock.Object;

            var cityUpdated = await _service.Put(cityDtoUpdate);
            Assert.NotNull(cityUpdated);
            Assert.Equal(cityDtoUpdate.Name, cityUpdated.Name);
            Assert.Equal(cityDtoUpdate.IBGECode, cityUpdated.IBGECode);
            Assert.Equal(cityDtoUpdate.StateId, cityUpdated.StateId);
        }
    }
}
