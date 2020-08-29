using ApiDDD.Domain.Dtos;
using ApiDDD.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.Login
{
    public class When_To_Run_FindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Can Run FindByLogin Method")]
        public async Task Can_Run_FindByLogin_Method()
        {
            var email = Faker.Internet.Email();
            var returnObject = new
            {
                authenticated = true,
                created = DateTime.Now,
                expiration = DateTime.Now,
                acessToken = Guid.NewGuid(),
                userName = email,
                message = "Usuário logado com sucesso"
            };

            var loginDto = new LoginDto()
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(s => s.FindByLogin(loginDto)).ReturnsAsync(returnObject);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
