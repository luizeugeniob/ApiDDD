using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.City
{
    public class When_To_Run_Get : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Can Run Get Method")]
        public async Task Can_Run_Get_Method()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.Get(CityId)).ReturnsAsync(cityDto);
            _service = _serviceMock.Object;

            var resultCity = await _service.Get(CityId);
            Assert.NotNull(resultCity);
            Assert.True(resultCity.Id == CityId);
            Assert.Equal(CityName, resultCity.Name);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CityDto)null));
            _service = _serviceMock.Object;

            var resultNullCity = await _service.Get(CityId);
            Assert.Null(resultNullCity);
        }
    }
}
