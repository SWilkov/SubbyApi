using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class Company
  {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("founded")]
    public DateTime Founded { get; set; }
    [JsonProperty("logoUrl")]
    public string LogoUrl { get; set; }
    [JsonProperty("altLogoUrl")]
    public string AltLogoUrl { get; set; }
    [JsonProperty("backgroundColor")]
    public string BackgroundColor { get; set; }
    [JsonProperty("weighting")]
    public int Weighting { get; set; }
    [JsonProperty("categoryLogos")]
    public ICollection<CategoryLogo> CategoryLogos { get; set; }
  }
}
