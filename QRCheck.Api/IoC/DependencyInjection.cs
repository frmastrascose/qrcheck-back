using Data.MongoDB.Configuration;
using Data.MongoDB.Repositories;
using Domain.Contracts;
using Domain.Contracts.ExternalServices;
using Domain.Contracts.Services;
using Domain.Services;
using External.Services;

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
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<ISmsExternalService, SmsExternalService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWhatsappService, WhatsappService>();
            services.AddScoped<IWhatsappExternalService, WhatsappExternalService>();
            return services;
        }
    }
}
