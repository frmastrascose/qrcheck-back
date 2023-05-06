using Data.MongoDB.Configuration;
using Data.MongoDB.Repositories;
using Domain.Contracts;
using Domain.Contracts.Services;
using Domain.Services;

namespace Hackaton.Api.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IDatabase, MongoDb>();

            //Services
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
