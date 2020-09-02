using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Interfaces.Services.User;
using ApiDDD.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.User.WhenToRunUpdate
{
    public class Return_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Update")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(s => s.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    UpdatedAt = DateTime.Now
                });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "Email é obrigatório.");

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
