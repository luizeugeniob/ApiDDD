using ApiDDD.Domain.Interfaces.Services.City;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.City
{
    public class When_To_Run_Post : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Can Run Post Method")]
        public async Task Can_Run_Post_Method()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Post(cityDtoCreate)).ReturnsAsync(cityDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cityDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CityName, result.Name);
            Assert.Equal(CityIBGECode, result.IBGECode);
            Assert.Equal(StateId, result.StateId);
        }
    }
}
