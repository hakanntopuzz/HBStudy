using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using HBCase.Data.Repositories;
using Microsoft.Extensions.Configuration;
using HBCase.Model.Settings;
using HBCase.Business.Services;

namespace HBCase.Bootstrapper
{
    public static class BusinessServiceExtension
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup));
            var assembly = AppDomain.CurrentDomain.Load("HBCase.Business");
            services.AddMediatR(assembly);
          
            services.AddScoped(typeof(IRepository<>), typeof(MongoDbRepository<>));
            services.AddScoped<ICacheService, RedisCacheService>();
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            return services;
        }
    }
}