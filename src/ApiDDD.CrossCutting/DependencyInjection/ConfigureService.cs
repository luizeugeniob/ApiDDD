using ApiDDD.Domain.Interfaces.Services.Address;
using ApiDDD.Domain.Interfaces.Services.City;
using ApiDDD.Domain.Interfaces.Services.State;
using ApiDDD.Domain.Interfaces.Services.User;
using ApiDDD.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDDD.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IAddressService, AddressService>();
        }
    }
}
