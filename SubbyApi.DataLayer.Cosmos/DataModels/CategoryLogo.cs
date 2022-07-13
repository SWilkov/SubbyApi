using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class CategoryLogo
  {
    [JsonProperty("category")]
    public string Category { get; set; }
    [JsonProperty("logoUrl")]
    public string LogoUrl { get; set; }
    [JsonProperty("color")]
    public string Color { get; set; }
    [JsonProperty("brand")]
    public string Brand { get; set; }
  }
}
