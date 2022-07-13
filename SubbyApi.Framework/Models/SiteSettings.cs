using SubbyApi.Framework.Interfaces;

namespace SubbyApi.Framework.Models
{
  public class SiteSettings : BaseFrameworkEntity
  {
    public bool UseLogoOnFilter { get; set; }
    public bool UseLogoOnSubscription { get; set; }
  }
}
