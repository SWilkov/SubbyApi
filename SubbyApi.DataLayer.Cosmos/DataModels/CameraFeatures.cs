using Newtonsoft.Json;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class CameraFeatures
  {
    [JsonProperty("videoHistory")]
    public string VideoHistory { get; set; }
    [JsonProperty("notifications")]
    public bool Notifications { get; set; }
    [JsonProperty("numberCameras")]
    public string NumberCameras { get; set; }
    [JsonProperty("highDefinition")]
    public bool HighDefinition { get; set; }
  }
}
