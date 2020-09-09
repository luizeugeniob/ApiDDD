using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.City
{
    public class When_To_Run_GetAll : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Can Run GetAll Method")]
        public async Task Can_Run_GetAll_Method()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(cityDtos);
            _service = _serviceMock.Object;

            var resultCitys = await _service.GetAll();
            Assert.NotNull(resultCitys);
            Assert.True(resultCitys.Count() == 10);

            var resultEmptyList = new List<CityDto>();
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(resultEmptyList.AsEnumerable());
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
