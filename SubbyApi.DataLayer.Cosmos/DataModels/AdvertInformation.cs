using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class AdvertInformation
  {
    [JsonProperty("topDeal")]
    public bool TopDeal { get; set; } = false;
    [JsonProperty("topDealUseCompanyLogo")]
    public bool TopDealUseCompanyLogo { get; set; }
  }
}
