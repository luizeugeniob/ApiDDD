﻿using ApiDDD.Domain.Dtos.User;
using ApiDDD.Domain.Interfaces.Services.User;
using ApiDDD.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.User.WhenToRunGetAll
{
    public class Return_GetAll
    {
        private UsersController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller GetAll")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(s => s.GetAll()).ReturnsAsync(
                new List<UserDto>
                {
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreatedAt = DateTime.Now
                    },
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreatedAt = DateTime.Now
                    }
                });

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}
