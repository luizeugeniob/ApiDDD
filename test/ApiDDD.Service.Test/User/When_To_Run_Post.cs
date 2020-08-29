using ApiDDD.Domain.Interfaces.Services.User;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.User
{
    public class When_To_Run_Post : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Can Run Post Method")]
        public async Task Can_Run_Post_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);
        }
    }
}
