using Heatray.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Heatray.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        _ = services.Configure<AuthConfiguration>(configuration.GetSection(AuthConfiguration.Section));
        return services;
    }
}