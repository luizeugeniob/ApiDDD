using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Interfaces.Services.User;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.User
{
    public class When_To_Run_GetAll : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Can Run GetAll Method")]
        public async Task Can_Run_GetAll_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(userDtos);
            _service = _serviceMock.Object;

            var resultUsers = await _service.GetAll();
            Assert.NotNull(resultUsers);
            Assert.True(resultUsers.Count() == 10);

            var resultEmptyList = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(resultEmptyList.AsEnumerable());
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
