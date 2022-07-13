using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SubbyApi.DataLayer.Cosmos.DataModels;
using SubbyApi.DataLayer.Cosmos.Interfaces;
using SubbyApi.DataLayer.Models;
using SubbyApi.Utils.Interfaces;
using SubbyApi.Utils.Models;

namespace SubbyApi.Functions
{
  public class GetSubscriptions
  {
    private readonly ILogger _logger;
    private readonly ICosmosDbService _dbService;
    private readonly IValidatorMessage<string> _categoryValidator;
    private readonly IQueryBuilder _queryBuilder;

    public GetSubscriptions(ILoggerFactory loggerFactory, ICosmosDbService dbService,
      IValidatorMessage<string> categoryValidator,
      IQueryBuilder queryBuilder)
    {
      _logger = loggerFactory.CreateLogger<GetSubscriptions>();
      _dbService = dbService;
      _categoryValidator = categoryValidator;
      _queryBuilder = queryBuilder;
    }

    [Function("subscriptions")]
    public async Task<HttpResponseData> Get([HttpTrigger(AuthorizationLevel.Anonymous, "get", 
      Route = "subscriptions/{category?}")] HttpRequestData req, string category)
    {
      _logger.LogInformation("C# HTTP trigger function processed a request.");

      category = string.IsNullOrWhiteSpace(category) ? "all" : category;

      category = string.IsNullOrWhiteSpace(category) ? "all" : category;

      var info = _categoryValidator.Validate(category);
      if (info.Result == ValidationResult.Invalid)
      {
        var bad = req.CreateResponse(HttpStatusCode.BadRequest);
        bad.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        bad.WriteString($"Invalid category: {category}");
        return bad;
      }

      IEnumerable<Subscription> subscriptions = null;

      if (category == "all")
        subscriptions = await _dbService.GetSubscriptionsAsync("SELECT * from c");
      else
      {
        var query = _queryBuilder.Build(QueryType.Category, category);
        subscriptions = await _dbService.GetSubscriptionsAsync(query);
      }

      if (subscriptions == null || !subscriptions.Any())
      {
        var nf = req.CreateResponse(HttpStatusCode.NotFound);
        return nf;
      }

      var response = req.CreateResponse(HttpStatusCode.OK);
      await response.WriteAsJsonAsync(subscriptions);
      return response;
    }
  }
}
