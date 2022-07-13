using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class TvFeatures
  {
    [JsonProperty("highDefinition")]
    public bool HighDefinition { get; set; }
    [JsonProperty("ultraHighDefinition")]
    public bool UltraHighDefinition { get; set; }
    [JsonProperty("numberDevices")]
    public int NumberDevices { get; set; }
  }
}
