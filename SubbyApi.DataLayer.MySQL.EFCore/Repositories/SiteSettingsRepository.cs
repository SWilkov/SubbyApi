using Microsoft.Extensions.DependencyInjection;
using SubbyApi.Framework.Models;
using SubbyApi.DataLayer.Interfaces;
using SubbyApi.DataLayer.MySQL.EFCore.Data;
using SubbyApi.DataLayer.MySQL.EFCore.DataModels;
using SubbyApi.DataLayer.MySQL.EFCore.Interfaces;

namespace SubbyApi.DataLayer.MySQL.EFCore.Repositories
{
  public class SiteSettingsRepository : IReadRepository<SiteSettings>
  {
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IMapper<SiteSettings, SiteSettingsDataModel> _mapper;

    public SiteSettingsRepository(IMapper<SiteSettings, SiteSettingsDataModel> mapper,
      IServiceScopeFactory serviceScopeFactory)
    {
      _serviceScopeFactory = serviceScopeFactory;
      _mapper = mapper;
    }

    public SiteSettings Get(int id)
    {
      using var scopeFactory = _serviceScopeFactory.CreateScope();
      var context = scopeFactory.ServiceProvider.GetRequiredService<SubbyContext>();

      var settings = context.SiteSettings.FirstOrDefault(x => x.Id == id); 
      if (settings == null) return null;

      return _mapper.Map(settings);
    }
  }
}
