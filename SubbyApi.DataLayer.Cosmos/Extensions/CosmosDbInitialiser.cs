using Microsoft.Azure.Cosmos;
using SubbyApi.DataLayer.Cosmos.Models;
using SubbyApi.DataLayer.Cosmos.Services;

namespace SubbyApi.DataLayer.Cosmos.Extensions
{
  public static class CosmosDbInitialiser
  {
    public static async Task<CosmosDbService> InitCosmosClientInstanceAsync(
      CosmosDbSettings settings)
    {
      var client = new CosmosClient(settings.AccountEndpoint);

      var service = new CosmosDbService(client, settings.DatabaseId, settings.ContainerId);
      var db = await client.CreateDatabaseIfNotExistsAsync(settings.DatabaseId);
      var containerProperties = new ContainerProperties(settings.ContainerId, settings.PartitionKeyPath);
      await db.Database.CreateContainerIfNotExistsAsync(containerProperties);

      return service;
    }
  }
}
