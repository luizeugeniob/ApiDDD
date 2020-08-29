using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.User
{
    public class When_To_Run_Get : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Can Run Get Method")]
        public async Task Can_Run_Get_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Get(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var resultUser = await _service.Get(UserId);
            Assert.NotNull(resultUser);
            Assert.True(resultUser.Id == UserId);
            Assert.Equal(UserName, resultUser.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _service = _serviceMock.Object;

            var resultNullUser = await _service.Get(UserId);
            Assert.Null(resultNullUser);
        }
    }
}
