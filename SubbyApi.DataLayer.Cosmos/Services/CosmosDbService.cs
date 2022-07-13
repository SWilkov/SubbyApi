using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using SubbyApi.DataLayer.Cosmos.DataModels;
using SubbyApi.DataLayer.Cosmos.Interfaces;

namespace SubbyApi.DataLayer.Cosmos.Services
{
  public class CosmosDbService : ICosmosDbService
  {
    private Container _container;
    public CosmosDbService(CosmosClient client,
      string databaseName,
      string containerName)
    {
      this._container = client.GetContainer(databaseName, containerName);
    }

    public async Task<Subscription> AddSubscriptionAsync(Subscription subscription)
    {
      if (subscription == null)
        throw new ArgumentNullException(nameof(subscription));
      if (!string.IsNullOrWhiteSpace(subscription.Id))
        throw new ArgumentException($"Subscription already has id: {subscription.Id}");

      try
      {
        subscription.Id = Guid.NewGuid().ToString();
        subscription.CreatedAt = DateTimeOffset.Now;
        var response = await this._container.CreateItemAsync(subscription, new PartitionKey(subscription.Id));
        return response.Resource;
      }
      catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
      {
        throw ex;
      }
    }

    public async Task DeleteSubscriptionAsync(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        throw new ArgumentException("invalid or missing id");

      var response = await _container.DeleteItemAsync<Subscription>(id, new PartitionKey(id));      
    }

    public async Task<Subscription> GetSubscriptionAsync(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        throw new ArgumentException("invalid or missing id");

      try
      {
        var response = await _container.ReadItemAsync<Subscription>(id, new PartitionKey(id));
        return response.Resource;
      }
      catch(CosmosException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
      {
        return null;
      }
    }

    public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(string queryString)
    {
      var query = _container.GetItemQueryIterator<Subscription>(new QueryDefinition(queryString));
      var results = new List<Subscription>();

      while (query.HasMoreResults)
      {
        try
        {
          var response = await query.ReadNextAsync();
          results.AddRange(response.ToList());
        }
        catch(CosmosException ex)
        {

        }
      }
      if (results != null && results.Any())
        return results.OrderByDescending(x => x.Company?.Weighting)
                      .ThenBy(x => x.Company?.Name)
                      .ThenByDescending(x => x.Weighting)
                      .ThenBy(x => x.Product)
                      .ThenBy(x => x.Name)
                      .Where(x => !x.Disabled);

      return results;
    }

    public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(QueryDefinition queryDefinition)
    {
      var query = _container.GetItemQueryIterator<Subscription>(queryDefinition);
      var results = new List<Subscription>();

      while (query.HasMoreResults)
      {
        try
        {
          var response = await query.ReadNextAsync();
          results.AddRange(response.ToList());
        }
        catch (CosmosException ex)
        {

        }
      }
      if (results != null && results.Any())
        return results.OrderByDescending(x => x.Company?.Weighting)
                      .ThenBy(x => x.Company?.Name)
                      .ThenByDescending(x => x.Weighting)
                      .ThenBy(x => x.Product)
                      .ThenBy(x => x.Name)
                      .Where(x => !x.Disabled);

      return results;
    }

    public async Task<Subscription> UpdateSubscriptionAsync(string id, Subscription subscription)
    {
      if (string.IsNullOrWhiteSpace(id))
        throw new ArgumentException("invalid or missing id");
      if (subscription == null)
        throw new ArgumentNullException(nameof(subscription));
      
      subscription.ModifiedAt = DateTimeOffset.Now;
      var response = await _container.UpsertItemAsync<Subscription>(subscription, new PartitionKey(id));
      return response.Resource;
    }
  }
}
