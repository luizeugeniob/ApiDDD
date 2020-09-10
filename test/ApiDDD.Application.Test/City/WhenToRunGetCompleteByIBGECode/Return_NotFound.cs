using ApiDDD.Application.Controllers;
using ApiDDD.Domain.Dtos.City;
using ApiDDD.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Application.Test.City.WhenToRunGetCompleteByIBGECode
{
    public class Return_NotFound
    {
        private CitiesController _controller;

        [Fact(DisplayName = "It Is Possible To Invoke The Controller GetCompleteByIBGECode")]
        public async Task It_Is_Possible_To_Invoke_The_Controller_GetCompleteByIBGECode()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(s => s.GetCompleteByIBGECode(It.IsAny<int>())).Returns(Task.FromResult((CityDtoComplete)null));

            _controller = new CitiesController(serviceMock.Object);
            var result = await _controller.GetCompleteByIBGECode(1);
            Assert.True(result is NotFoundResult);
        }
    }
}
