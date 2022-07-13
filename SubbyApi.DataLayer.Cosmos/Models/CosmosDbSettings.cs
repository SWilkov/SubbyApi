namespace SubbyApi.DataLayer.Cosmos.Models
{
  public class CosmosDbSettings
  {
    public string DatabaseId { get; set; }
    public string ContainerId { get; set; }
    public string AccountEndpoint { get; set; }
    public string PartitionKeyPath { get; set; }
    public CosmosDbSettings()
    {

    }
    public CosmosDbSettings(string databaseId, string containerId, 
      string accountEndpoint, string partitionKeyPath)
    {
      this.DatabaseId = databaseId;
      this.ContainerId = containerId;
      this.AccountEndpoint = accountEndpoint;
      this.PartitionKeyPath = partitionKeyPath;
    }
  }
}
