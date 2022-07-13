using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class PriceDetail
  {
    [JsonProperty("price")]
    public decimal Price { get; set; }
    [JsonProperty("renewalPeriod")]
    public string RenewalPeriod { get; set; }
    [JsonProperty("selected")]
    public bool Selected { get; set; }
  }
}
