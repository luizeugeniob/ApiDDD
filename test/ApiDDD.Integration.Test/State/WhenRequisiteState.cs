using ApiDDD.Domain.Dtos.State;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Integration.Test.State
{
    public class WhenRequisiteState : BaseIntegration
    {
        [Fact]
        public async Task It_Is_Possible_To_Run_State_Crud()
        {
            await AddToken();

            // Get All
            var response = await Client.GetAsync($"{HostApi}/states");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseString = await response.Content.ReadAsStringAsync();
            var stateDtos = JsonConvert.DeserializeObject<IEnumerable<StateDto>>(responseString);
            Assert.NotNull(stateDtos);
            Assert.True(stateDtos.Count() == 27);
            Assert.True(stateDtos.Where(x => x.ShortName.Equals("RS")).Count() == 1);

            // Get
            var id = stateDtos.Where(x => x.ShortName.Equals("RS")).FirstOrDefault().Id;
            response = await Client.GetAsync($"{HostApi}/states/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            var stateDto = JsonConvert.DeserializeObject<StateDto>(responseString);
            Assert.NotNull(stateDto);
            Assert.Equal("Rio Grande do Sul", stateDto.Name);
            Assert.Equal("RS", stateDto.ShortName);
        }
    }
}
