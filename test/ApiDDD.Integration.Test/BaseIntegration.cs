using ApiDDD.Application;
using ApiDDD.CrossCutting.Mappings;
using ApiDDD.Data.Context;
using ApiDDD.Domain.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Integration.Test
{
    public class BaseIntegration : IDisposable
    {
        public MyContext MyContext { get; set; }
        public HttpClient Client { get; set; }
        public IMapper Mapper { get; set; }
        public string HostApi { get; set; }
        public HttpResponseMessage Response { get; set; }

        public BaseIntegration()
        {
            HostApi = "http://localhost:5000/api";
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();
            var server = new TestServer(builder);

            MyContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            MyContext.Database.Migrate();

            Mapper = new AutoMapperFixture().GetMapper();

            Client = server.CreateClient();
        }

        public async Task AddToken()
        {
            var loginDto = new LoginDto
            {
                Email = "admin@mail.com"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{HostApi}/login", Client);

            if (resultLogin.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonReponse = await resultLogin.Content.ReadAsStringAsync();
                var loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(jsonReponse);

                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponseDto.AcessToken);
            }
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataclass), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            MyContext.Dispose();
            Client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new DtoToModelProfile());
                conf.AddProfile(new EntityToDtoProfile());
                conf.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {

        }
    }
}
