using ApiDDD.Domain.Interfaces.Services.City;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.City
{
    public class When_To_Run_Delete : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Can Run Delete Method")]
        public async Task Can_Run_Delete_Method()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.Delete(CityId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var isDeleted = await _service.Delete(CityId);
            Assert.True(isDeleted);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            isDeleted = await _service.Delete(Guid.NewGuid());
            Assert.False(isDeleted);
        }
    }
}
