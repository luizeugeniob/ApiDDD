using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunGetCompleteById
{
    public class Return_NotFound
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller GetCompleteById")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_GetCompleteById()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(s => s.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((CityDtoComplete)null));

            _controller = new CitiesController(serviceMock.Object);
            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
