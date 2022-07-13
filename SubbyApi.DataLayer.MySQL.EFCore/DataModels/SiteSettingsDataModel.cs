using System.ComponentModel.DataAnnotations.Schema;

namespace SubbyApi.DataLayer.MySQL.EFCore.DataModels
{
  public class SiteSettingsDataModel : BaseDataModel
  {
    [Column("use_logo_on_filter")]   
    public bool UseLogoOnFilter { get; set; }
    [Column("use_logo_on_subscription")]
    public bool UseLogoOnSubscription { get; set; }
  }
}
