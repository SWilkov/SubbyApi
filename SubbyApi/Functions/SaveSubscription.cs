using System;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SubbyApi.DataLayer.Cosmos.DataModels;
using SubbyApi.DataLayer.Cosmos.Interfaces;
using SubbyApi.Utils.Interfaces;

namespace SubbyApi.Functions
{
  public class SaveSubscription
  {
    private readonly ILogger _logger;
    private readonly IValidatorMessage<Subscription> _validator;
    private readonly ICosmosDbService _dbService;

    public SaveSubscription(ILoggerFactory loggerFactory, IValidatorMessage<Subscription> validator,
      ICosmosDbService dbService)
    {
      _logger = loggerFactory.CreateLogger<SaveSubscription>();
      _validator = validator;
      _dbService = dbService;
    }

    [Function("save-subscription")]
    public async Task<HttpResponseData> Post([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
    {
      _logger.LogInformation("C# HTTP trigger function processed a request.");

      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      var subscription = JsonConvert.DeserializeObject<Subscription>(requestBody);

      if (subscription == null)
      {
        var noSub = req.CreateResponse(HttpStatusCode.BadRequest);
        await noSub.WriteStringAsync($"Could not find a subscription");
        return noSub;
      }

      //Validate incoming subscription
      var validation = _validator.Validate(subscription);
      if (validation.Result == Utils.Models.ValidationResult.Invalid)
      {
        var notValid = req.CreateResponse(HttpStatusCode.BadRequest);
        await notValid.WriteStringAsync($"Failed validation: {validation.Message}");
        return notValid;
      }

      Subscription sub = null;
      //Brand new subscription
      if (string.IsNullOrWhiteSpace(subscription.Id))
      {
        var subs = await _dbService.GetSubscriptionsAsync($"SELECT * FROM c WHERE c.company.name = \"{subscription.Company.Name}\" AND c.product = \"{subscription.Product}\" AND c.name = \"{subscription.Name}\" AND c.price = {subscription.Price}");
        if (subs != null && subs.Any())
        {
          var exists = req.CreateResponse(HttpStatusCode.Conflict);
          return exists;
        }

        sub = await _dbService.AddSubscriptionAsync(subscription);
      }
      else
      {
        sub = await _dbService.UpdateSubscriptionAsync(subscription.Id, subscription);
      }


      var response = req.CreateResponse(HttpStatusCode.OK);
      response.Headers.Add("Content-Type", "application/json");
      await response.WriteAsJsonAsync<Subscription>(sub);
      return response;
    }
  }
}
