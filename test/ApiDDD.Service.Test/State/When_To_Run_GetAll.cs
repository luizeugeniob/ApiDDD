using ApiDDD.Domain.Dtos.State;
using ApiDDD.Domain.Interfaces.Services.State;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Service.Test.State
{
    public class When_To_Run_GetAll : StateTests
    {
        private IStateService _service;
        private Mock<IStateService> _serviceMock;

        [Fact(DisplayName = "Can Run GetAll Method")]
        public async Task Can_Run_GetAll_Method()
        {
            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(stateDtos);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var resultEmptyList = new List<StateDto>();
            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(s => s.GetAll()).ReturnsAsync(resultEmptyList.AsEnumerable());
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
