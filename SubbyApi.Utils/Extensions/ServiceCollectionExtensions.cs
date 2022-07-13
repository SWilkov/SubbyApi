using Microsoft.Extensions.DependencyInjection;
using SubbyApi.Utils.Interfaces;
using SubbyApi.Utils.Services;

namespace SubbyApi.Utils.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSubbyApiUtils(this IServiceCollection services)
        {
            services.AddScoped<IEnvironmentService, EnvironmentService>();
        }
    }
}
