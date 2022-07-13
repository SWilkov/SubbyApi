using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class VideoGameFeatures
  {
    [JsonProperty("cloudGaming")]
    public bool CloudGaming { get; set; }
    [JsonProperty("numberGames")]
    public string NumberGames { get; set; }
    [JsonProperty("highlights")]
    public string[] Highlights { get; set; }
    [JsonProperty("people")]
    public int People { get; set; }
  }
}
