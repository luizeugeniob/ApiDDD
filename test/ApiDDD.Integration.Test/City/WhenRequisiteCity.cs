using ApiDDD.Domain.Dtos.City;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Integration.Test.City
{
    public class WhenRequisiteCity : BaseIntegration
    {
        [Fact]
        public async Task It_Is_Possible_To_Run_City_Crud()
        {
            await AddToken();

            var cityDtoCreate = new CityDtoCreate
            {
                Name = "Passo Fundo",
                IBGECode = 4314100,
                StateId = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1")
            };

            // Post
            var response = await PostJsonAsync(cityDtoCreate, $"{HostApi}/cities", Client);
            var responseString = await response.Content.ReadAsStringAsync();
            var cityDtoCreateResult = JsonConvert.DeserializeObject<CityDtoCreateResult>(responseString);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("Passo Fundo", cityDtoCreateResult.Name);
            Assert.Equal(4314100, cityDtoCreateResult.IBGECode);
            Assert.False(cityDtoCreateResult.Id == default);

            // Get All
            response = await Client.GetAsync($"{HostApi}/cities");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            var cityDtos = JsonConvert.DeserializeObject<IEnumerable<CityDto>>(responseString);
            Assert.NotNull(cityDtos);
            Assert.True(cityDtos.Count() > 0);
            Assert.True(cityDtos.Where(x => x.Id == cityDtoCreateResult.Id).Count() == 1);

            // Put
            var cityDtoUpdate = new CityDtoUpdate
            {
                Id = cityDtoCreateResult.Id,
                Name = "Paraí",
                IBGECode = 4314001,
                StateId = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1")
            };
            var content = new StringContent(JsonConvert.SerializeObject(cityDtoUpdate), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostApi}/cities", content);
            responseString = await response.Content.ReadAsStringAsync();
            var cityDtoUpdateResult = JsonConvert.DeserializeObject<CityDtoUpdateResult>(responseString);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(cityDtoCreateResult.Id, cityDtoUpdateResult.Id);
            Assert.NotEqual(cityDtoCreateResult.Name, cityDtoUpdateResult.Name);
            Assert.NotEqual(cityDtoCreateResult.IBGECode, cityDtoUpdateResult.IBGECode);
            Assert.Equal(cityDtoUpdate.Id, cityDtoUpdateResult.Id);
            Assert.Equal(cityDtoUpdate.Name, cityDtoUpdateResult.Name);
            Assert.Equal(cityDtoUpdate.IBGECode, cityDtoUpdateResult.IBGECode);

            // Get
            response = await Client.GetAsync($"{HostApi}/cities/{cityDtoUpdateResult.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            var cityDto = JsonConvert.DeserializeObject<CityDto>(responseString);
            Assert.NotNull(cityDto);
            Assert.Equal(cityDtoUpdateResult.Name, cityDto.Name);
            Assert.Equal(cityDtoUpdateResult.IBGECode, cityDto.IBGECode);

            // GetCompleteById
            response = await Client.GetAsync($"{HostApi}/cities/completeById/{cityDtoUpdateResult.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            var cityDtoComplete = JsonConvert.DeserializeObject<CityDtoComplete>(responseString);
            Assert.NotNull(cityDtoComplete);
            Assert.Equal(cityDtoUpdateResult.Name, cityDtoComplete.Name);
            Assert.Equal(cityDtoUpdateResult.IBGECode, cityDtoComplete.IBGECode);
            Assert.NotNull(cityDtoComplete.State);
            Assert.Equal("Rio Grande do Sul", cityDtoComplete.State.Name);
            Assert.Equal("RS", cityDtoComplete.State.ShortName);

            // GetCompleteByIBGECode
            response = await Client.GetAsync($"{HostApi}/cities/completeByIBGECode/{cityDtoUpdateResult.IBGECode}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            cityDtoComplete = JsonConvert.DeserializeObject<CityDtoComplete>(responseString);
            Assert.NotNull(cityDtoComplete);
            Assert.Equal(cityDtoUpdateResult.Name, cityDtoComplete.Name);
            Assert.Equal(cityDtoUpdateResult.IBGECode, cityDtoComplete.IBGECode);
            Assert.NotNull(cityDtoComplete.State);
            Assert.Equal("Rio Grande do Sul", cityDtoComplete.State.Name);
            Assert.Equal("RS", cityDtoComplete.State.ShortName);

            // Delete
            response = await Client.DeleteAsync($"{HostApi}/cities/{cityDto.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get after Delete
            response = await Client.GetAsync($"{HostApi}/cities/{cityDto.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
