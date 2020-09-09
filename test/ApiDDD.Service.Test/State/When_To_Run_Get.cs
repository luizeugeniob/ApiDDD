using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Interfaces.Services.State;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.State
{
    public class When_To_Run_Get : StateTests
    {
        private IStateService _service;
        private Mock<IStateService> _serviceMock;

        [Fact(DisplayName = "Can Run Get Method")]
        public async Task Can_Run_Get_Method()
        {
            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(s => s.Get(StateId)).ReturnsAsync(stateDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(StateId);
            Assert.NotNull(result);
            Assert.True(result.Id == StateId);
            Assert.Equal(Name, result.Name);

            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(s => s.Get(It.IsAny<Guid>())).Returns(Task.FromResult((StateDto)null));
            _service = _serviceMock.Object;

            var resultNull = await _service.Get(StateId);
            Assert.Null(resultNull);
        }
    }
}
