using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunDelete
{
    public class Return_Deleted
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller Delete")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_Delete()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(s => s.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _controller = new CitiesController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((bool)resultValue);
        }
    }
}
