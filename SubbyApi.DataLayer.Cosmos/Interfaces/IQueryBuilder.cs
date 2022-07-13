using Microsoft.Azure.Cosmos;
using SubbyApi.DataLayer.Models;

namespace SubbyApi.DataLayer.Cosmos.Interfaces
{
  public interface IQueryBuilder
  {
    QueryDefinition Build(QueryType queryType, params string[] args);
  }
}
