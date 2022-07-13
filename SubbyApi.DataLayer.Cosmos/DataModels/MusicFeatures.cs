using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class MusicFeatures
  {
    [JsonProperty("highDefinition")]
    public bool HighDefinition { get; set; }
    [JsonProperty("ultraHighDefinition")]
    public bool UltraHighDefinition { get; set; }
    [JsonProperty("numberSongs")]
    public string NumberSongs { get; set; }
    [JsonProperty("speedStandardDefinition")]
    public string SpeedStandardDefinition { get; set; }
    [JsonProperty("speedHighDefinition")]
    public string SpeedHighDefinition { get; set; }
    [JsonProperty("speedUltraHighDefinition")]
    public string SpeedUltraHighDefinition { get; set; }
    [JsonProperty("people")]
    public int People { get; set; }
  }
}
