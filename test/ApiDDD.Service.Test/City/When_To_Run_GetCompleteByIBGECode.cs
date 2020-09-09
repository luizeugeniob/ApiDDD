using ApiDDD.Domain.Interfaces.Services.City;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.City
{
    public class When_To_Run_GetCompleteByIBGECode : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Can Run GetCompleteByIBGECode Method")]
        public async Task Can_Run_GetCompleteByIBGECode_Method()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGECode(CityIBGECode)).ReturnsAsync(cityDtoComplete);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteByIBGECode(CityIBGECode);
            Assert.NotNull(result);
            Assert.True(result.Id == CityId);
            Assert.Equal(CityName, result.Name);
            Assert.Equal(CityIBGECode, result.IBGECode);
            Assert.NotNull(result.State);
        }
    }
}
