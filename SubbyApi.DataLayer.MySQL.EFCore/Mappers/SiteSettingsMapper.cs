using SubbyApi.Framework.Models;
using SubbyApi.DataLayer.MySQL.EFCore.DataModels;
using SubbyApi.DataLayer.MySQL.EFCore.Interfaces;

namespace SubbyApi.DataLayer.MySQL.EFCore.Mappers
{
  public class SiteSettingsMapper : IMapper<SiteSettings, SiteSettingsDataModel>
  {
    public SiteSettings Map(SiteSettingsDataModel source)
    {
      return new SiteSettings
      {
        UseLogoOnFilter = source.UseLogoOnFilter,
        UseLogoOnSubscription = source.UseLogoOnSubscription
      };
    }

    public SiteSettingsDataModel Map(SiteSettings source)
    {
      return new SiteSettingsDataModel
      {
        UseLogoOnFilter = source.UseLogoOnFilter,
        UseLogoOnSubscription = source.UseLogoOnSubscription
      };
    }
  }
}
