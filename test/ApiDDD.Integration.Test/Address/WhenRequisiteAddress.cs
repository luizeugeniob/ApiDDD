using ApiDDD.Domain.Dtos.Address;
using ApiDDD.Domain.Dtos.City;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Integration.Test.Address
{
    public class WhenRequisiteAddress : BaseIntegration
    {
        [Fact]
        public async Task It_Is_Possible_To_Run_Address_Crud()
        {
            await AddToken();

            var cityDtoCreate = new CityDtoCreate
            {
                Name = "Passo Fundo",
                IBGECode = 4314100,
                StateId = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1")
            };

            // Post City
            var response = await PostJsonAsync(cityDtoCreate, $"{HostApi}/cities", Client);
            var responseString = await response.Content.ReadAsStringAsync();
            var cityDtoCreateResult = JsonConvert.DeserializeObject<CityDtoCreateResult>(responseString);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("Passo Fundo", cityDtoCreateResult.Name);
            Assert.Equal(4314100, cityDtoCreateResult.IBGECode);
            Assert.False(cityDtoCreateResult.Id == default);

            var addressDtoCreate = new AddressDtoCreate
            {
                Street = "Rua Morom",
                ZipCode = "99.010-030",
                Number = "930",
                CityId = cityDtoCreateResult.Id
            };

            // Post
            response = await PostJsonAsync(addressDtoCreate, $"{HostApi}/addresses", Client);
            responseString = await response.Content.ReadAsStringAsync();
            var addressDtoCreateResult = JsonConvert.DeserializeObject<AddressDtoCreateResult>(responseString);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("Rua Morom", addressDtoCreateResult.Street);
            Assert.Equal("99.010-030", addressDtoCreateResult.ZipCode);
            Assert.Equal("930", addressDtoCreateResult.Number);
            Assert.False(addressDtoCreateResult.Id == default);

            // Put
            var addressDtoUpdate = new AddressDtoUpdate
            {
                Id = addressDtoCreateResult.Id,                
                Street = "Rua Dez de Abril",
                ZipCode = "99.010-210",
                Number = "403",
                CityId = cityDtoCreateResult.Id
            };
            var content = new StringContent(JsonConvert.SerializeObject(addressDtoUpdate), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostApi}/addresses", content);
            responseString = await response.Content.ReadAsStringAsync();
            var addressDtoUpdateResult = JsonConvert.DeserializeObject<AddressDtoUpdateResult>(responseString);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(addressDtoCreateResult.Id, addressDtoUpdateResult.Id);
            Assert.NotEqual(addressDtoCreateResult.Street, addressDtoUpdateResult.Street);
            Assert.NotEqual(addressDtoCreateResult.ZipCode, addressDtoUpdateResult.ZipCode);
            Assert.NotEqual(addressDtoCreateResult.Number, addressDtoUpdateResult.Number);
            Assert.Equal(addressDtoUpdate.Id, addressDtoUpdateResult.Id);
            Assert.Equal(addressDtoUpdate.Street, addressDtoUpdateResult.Street);
            Assert.Equal(addressDtoUpdate.ZipCode, addressDtoUpdateResult.ZipCode);
            Assert.Equal(addressDtoUpdate.Number, addressDtoUpdateResult.Number);

            // Get
            response = await Client.GetAsync($"{HostApi}/addresses/{addressDtoUpdateResult.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            var addressDto = JsonConvert.DeserializeObject<AddressDto>(responseString);
            Assert.NotNull(addressDto);
            Assert.Equal(addressDtoUpdateResult.Street, addressDto.Street);
            Assert.Equal(addressDtoUpdateResult.ZipCode, addressDto.ZipCode);
            Assert.Equal(addressDtoUpdateResult.Number, addressDto.Number);

            // GetByZipCode
            response = await Client.GetAsync($"{HostApi}/addresses/byZipCode/{addressDtoUpdateResult.ZipCode}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            addressDto = JsonConvert.DeserializeObject<AddressDto>(responseString);
            Assert.NotNull(addressDto);
            Assert.Equal(addressDtoUpdateResult.Street, addressDto.Street);
            Assert.Equal(addressDtoUpdateResult.ZipCode, addressDto.ZipCode);
            Assert.Equal(addressDtoUpdateResult.Number, addressDto.Number);

            // Delete
            response = await Client.DeleteAsync($"{HostApi}/addresses/{addressDto.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get after Delete
            response = await Client.GetAsync($"{HostApi}/addresses/{addressDto.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
