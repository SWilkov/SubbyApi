using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class Trial
  {
    [JsonProperty("price")]
    public decimal Price { get; set; }
    [JsonProperty("days")]
    public int Days { get; set; }
    [JsonProperty("months")]
    public int Months { get; set; }
    [JsonProperty("years")]
    public int Years { get; set; }
  }
}
