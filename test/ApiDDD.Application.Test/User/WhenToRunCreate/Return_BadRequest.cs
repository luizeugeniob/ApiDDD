using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Interfaces.Services.User;
using ApiDDD.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.User.WhenToRunCreate
{
    public class Return_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Create")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(s => s.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreatedAt = DateTime.Now
                });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Nome é obrigatório.");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(s => s.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
