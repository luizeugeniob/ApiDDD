using ApiDDD.Domain.Dtos.User;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDDD.Integration.Test.User
{
    public class WhenRequisiteUser : BaseIntegration
    {
        public string _name { get; set; }
        public string _email { get; set; }

        [Fact]
        public async Task It_Is_Possible_To_Run_User_Crud()
        {
            await AddToken();
            _name = Faker.Name.FullName();
            _email = Faker.Internet.Email();

            var userDtoCreate = new UserDtoCreate
            {
                Name = _name,
                Email = _email
            };

            // Post
            var response = await PostJsonAsync(userDtoCreate, $"{HostApi}/users", Client);
            var responseString = await response.Content.ReadAsStringAsync();
            var userDtoCreateResult = JsonConvert.DeserializeObject<UserDtoCreateResult>(responseString);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, userDtoCreateResult.Name);
            Assert.Equal(_email, userDtoCreateResult.Email);
            Assert.False(userDtoCreateResult.Id == default);

            // Get All
            response = await Client.GetAsync($"{HostApi}/users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            var userDtos = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(responseString);
            Assert.NotNull(userDtos);
            Assert.True(userDtos.Count() > 0);
            Assert.True(userDtos.Where(x => x.Id == userDtoCreateResult.Id).Count() == 1);

            // Put
            var userDtoUpdate = new UserDtoUpdate
            {
                Id = userDtoCreateResult.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };
            var content = new StringContent(JsonConvert.SerializeObject(userDtoUpdate), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostApi}/users", content);
            responseString = await response.Content.ReadAsStringAsync();
            var userDtoUpdateResult = JsonConvert.DeserializeObject<UserDtoUpdateResult>(responseString);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(userDtoCreateResult.Id, userDtoUpdateResult.Id);
            Assert.NotEqual(userDtoCreateResult.Name, userDtoUpdateResult.Name);
            Assert.NotEqual(userDtoCreateResult.Email, userDtoUpdateResult.Email);
            Assert.Equal(userDtoUpdate.Id, userDtoUpdateResult.Id);
            Assert.Equal(userDtoUpdate.Name, userDtoUpdateResult.Name);
            Assert.Equal(userDtoUpdate.Email, userDtoUpdateResult.Email);

            // Get
            response = await Client.GetAsync($"{HostApi}/users/{userDtoUpdateResult.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            responseString = await response.Content.ReadAsStringAsync();
            var userDto = JsonConvert.DeserializeObject<UserDto>(responseString);
            Assert.NotNull(userDto);
            Assert.Equal(userDtoUpdateResult.Name, userDto.Name);
            Assert.Equal(userDtoUpdateResult.Email, userDto.Email);


            // Delete
            response = await Client.DeleteAsync($"{HostApi}/users/{userDto.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get after Delete
            response = await Client.GetAsync($"{HostApi}/users/{userDto.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
