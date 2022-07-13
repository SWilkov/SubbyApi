using Microsoft.Azure.Cosmos;
using SubbyApi.DataLayer.Cosmos.Interfaces;
using SubbyApi.DataLayer.Models;

namespace SubbyApi.DataLayer.Cosmos.QueryBuilders
{
  public class CategoryQueryBuilder : IQueryBuilder
  {
    public QueryDefinition Build(QueryType queryType, params string[] args)
    {
      if (queryType != QueryType.Category)
        throw new ArgumentException($"Expecting Category but received ${queryType.ToString()}");

      if (args == null || args.Length != 1)
        throw new ArgumentException($"Invalid number of args expectin 1 recieved ${args.Length}");
          
      return new QueryDefinition("SELECT * FROM c WHERE c.category = @category")
                                  .WithParameter("@category", args[0]);
    }    
  }
}
