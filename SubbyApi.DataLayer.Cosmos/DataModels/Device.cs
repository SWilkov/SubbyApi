using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class Device
  {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("category")]
    public string Category { get; set; }
    [JsonProperty("logoUrl")]
    public string LogoUrl { get; set; }
  }
}
