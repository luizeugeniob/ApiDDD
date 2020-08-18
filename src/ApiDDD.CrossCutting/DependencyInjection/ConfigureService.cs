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
        }
    }
}
