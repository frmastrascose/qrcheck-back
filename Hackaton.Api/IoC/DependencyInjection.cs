using Data.MongoDB.Configuration;
using Data.MongoDB.Repositories;
using Domain.Contracts;

namespace Hackaton.Api.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IDatabase, MongoDb>();

            return services;
        }
    }
}
