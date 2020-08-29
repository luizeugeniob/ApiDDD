using ApiDDD.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.User
{
    public class When_To_Run_Delete : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Can Run Delete Method")]
        public async Task Can_Run_Delete_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Delete(UserId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var isDeleted = await _service.Delete(UserId);
            Assert.True(isDeleted);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            isDeleted = await _service.Delete(Guid.NewGuid());
            Assert.False(isDeleted);
        }
    }
}
