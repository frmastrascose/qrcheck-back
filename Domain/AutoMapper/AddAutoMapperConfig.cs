using Microsoft.Extensions.DependencyInjection;

namespace Domain.AutoMapper;

public static class AddAutoMapperConfig
{
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddAutoMapper(new Type[]
        {
        typeof(Profiles),
        });
    }
}