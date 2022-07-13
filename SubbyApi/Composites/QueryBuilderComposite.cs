using Microsoft.Azure.Cosmos;
using SubbyApi.DataLayer.Cosmos.Interfaces;
using SubbyApi.DataLayer.Models;
using System.Collections.Generic;

namespace SubbyApi.Composites
{
  public class QueryBuilderComposite : IQueryBuilder
  {
    private readonly IDictionary<QueryType, IQueryBuilder> _builders;
    public QueryBuilderComposite(IDictionary<QueryType, IQueryBuilder> builders)
    {
      _builders = builders;
    }

    public QueryDefinition Build(QueryType queryType, params string[] args) =>
      _builders[queryType].Build(queryType, args);
  }
}
