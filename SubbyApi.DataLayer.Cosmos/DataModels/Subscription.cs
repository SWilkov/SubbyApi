using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class Subscription
  {
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }
    [JsonProperty("modifiedAt")]
    public DateTimeOffset ModifiedAt { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("company")]
    public Company Company { get; set; }
    [JsonProperty("product")]
    public string Product { get; set; }
    [JsonProperty("price")]
    public decimal Price { get; set; }
    [JsonProperty("cancelAnytime")]
    public bool CancelAnytime { get; set; }
    [JsonProperty("logoUrl")]
    public string LogoUrl { get; set; }
    [JsonProperty("logoBackground")]
    public string LogoBackground { get; set; }
    [JsonProperty("renewalPeriod")]
    public string RenewalPeriod { get; set; }
    [JsonProperty("category")]
    public string Category { get; set; }
    [JsonProperty("trials")]
    public ICollection<Trial> Trials { get; set; }
    [JsonProperty("devices")]
    public ICollection<Device> Devices { get; set; }
    [JsonProperty("adFree")]
    public bool AdFree { get; set; }
    [JsonProperty("highlights")]
    public string[] Highlights { get; set; }
    [JsonProperty("numberSelected")]
    public int NumberSelected { get; set; } = 0;
    [JsonProperty("specialNote")]
    public string SpecialNote { get; set; }

    //features
    [JsonProperty("tvFeatures")]
    public TvFeatures TvFeatures { get; set; }
    [JsonProperty("musicFeatures")]
    public MusicFeatures MusicFeatures { get; set; }
    [JsonProperty("videoGameFeatures")]
    public VideoGameFeatures VideoGameFeatures { get; set; }
    [JsonProperty("cameraFeatures")]
    public CameraFeatures CameraFeatures { get; set; }

    //misc
    [JsonProperty("advertInformation")]
    public AdvertInformation AdvertInformation { get; set; }
    [JsonProperty("subscriptionOffer")]
    public SubscriptionOffer SubscriptionOffer { get; set; }
    [JsonProperty("tags")]
    public string[] Tags { get; set; }
    [JsonProperty("weighting")]
    public int Weighting { get; set; }

    [JsonProperty("priceDetails")]
    public ICollection<PriceDetail> PriceDetails { get; set; }
    [JsonProperty("link")]
    public string Link { get; set; }
    [JsonProperty("disabled")]
    public bool Disabled { get; set; } = false;
  }
}
