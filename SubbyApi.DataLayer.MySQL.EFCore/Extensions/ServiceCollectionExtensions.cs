using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SubbyApi.Framework.Models;
using SubbyApi.DataLayer.Interfaces;
using SubbyApi.DataLayer.MySQL.EFCore.Data;
using SubbyApi.DataLayer.MySQL.EFCore.DataModels;
using SubbyApi.DataLayer.MySQL.EFCore.Interfaces;

namespace SubbyApi.DataLayer.MySQL.EFCore.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static void AddMySQLCore(this IServiceCollection services, string connectionString, int serverRetrys = 5)
    {
      services.AddDbContext<SubbyContext>(options =>
      {
        options.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 7, 32)),

          mySqlOptions =>
          {
            mySqlOptions.EnableRetryOnFailure(serverRetrys, TimeSpan.FromSeconds(10), null);
          });
       });

      services.AddScoped<IMapper<SiteSettings, SiteSettingsDataModel>, Mappers.SiteSettingsMapper>();

      services.AddScoped<IReadRepository<SiteSettings>, Repositories.SiteSettingsRepository>();
    }
  }
}
