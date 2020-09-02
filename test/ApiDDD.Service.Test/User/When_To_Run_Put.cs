using ApiDDD.Domain.Interfaces.Services.User;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.User
{
    public class When_To_Run_Put : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Can Run Put Method")]
        public async Task Can_Run_Put_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var userCreated = await _service.Post(userDtoCreate);
            Assert.NotNull(userCreated);
            Assert.Equal(UserName, userCreated.Name);
            Assert.Equal(UserEmail, userCreated.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var userUpdated = await _service.Put(userDtoUpdate);
            Assert.NotNull(userUpdated);
            Assert.Equal(userDtoUpdate.Name, userUpdated.Name);
            Assert.Equal(userDtoUpdate.Email, userUpdated.Email);
        }
    }
}
