using Microsoft.Azure.Cosmos;
using SubbyApi.DataLayer.Cosmos.DataModels;

namespace SubbyApi.DataLayer.Cosmos.Interfaces
{
  public interface ICosmosDbService
  {
    Task<IEnumerable<Subscription>> GetSubscriptionsAsync(string query);
    Task<IEnumerable<Subscription>> GetSubscriptionsAsync(QueryDefinition queryDefinition);
    Task<Subscription> GetSubscriptionAsync(string id);
    Task<Subscription> AddSubscriptionAsync(Subscription Subscription);
    Task<Subscription> UpdateSubscriptionAsync(string id, Subscription Subscription);
    Task DeleteSubscriptionAsync(string id);
  }
}
