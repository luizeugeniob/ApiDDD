using ApiDDD.Data.Context;
using ApiDDD.Data.Implementations;
using ApiDDD.Data.Repository;
using ApiDDD.Domain.Interfaces;
using ApiDDD.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApiDDD.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "sqlserver")
                services.AddDbContext<MyContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            else
                services.AddDbContext<MyContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
        }
    }
}
