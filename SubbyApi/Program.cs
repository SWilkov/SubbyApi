using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SubbyApi.Composites;
using SubbyApi.DataLayer.Cosmos.DataModels;
using SubbyApi.DataLayer.Cosmos.Extensions;
using SubbyApi.DataLayer.Cosmos.Interfaces;
using SubbyApi.DataLayer.Cosmos.Models;
using SubbyApi.DataLayer.Cosmos.QueryBuilders;
using SubbyApi.DataLayer.Models;
using SubbyApi.DataLayer.MySQL.EFCore.Extensions;
using SubbyApi.Framework.Interfaces;
using SubbyApi.Framework.Models;
using SubbyApi.Services;
using SubbyApi.Utils.Extensions;
using SubbyApi.Utils.Interfaces;
using SubbyApi.Validators;
using System.Text.Json;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()

    .ConfigureServices(services =>
    {
      services.Configure<JsonSerializerOptions>(opts =>
      {
        opts.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
      });

      var cosmosDbSettings = new CosmosDbSettings(
        Environment.GetEnvironmentVariable("CosmosDbSettings:DatabaseId") ?? throw new ArgumentException("Missing DatabaseId"),
        Environment.GetEnvironmentVariable("CosmosDbSettings:ContainerId") ?? throw new ArgumentException("Missing ContainerId"),
        Environment.GetEnvironmentVariable("CosmosDbSettings:AccountEndpoint") ?? throw new ArgumentException("Missing AccountEndpoint"),
        Environment.GetEnvironmentVariable("CosmosDbSettings:PartitionKeyPath") ?? throw new ArgumentException("Missing Partition Key"));

      #region Databases
      services.AddSingleton<ICosmosDbService>(
        CosmosDbInitialiser.InitCosmosClientInstanceAsync(cosmosDbSettings).GetAwaiter().GetResult());

      services.AddMySQLCore(Environment.GetEnvironmentVariable("SUBBY_MYSQL_CONN_STR") ?? String.Empty);
      #endregion

      services.AddSubbyApiUtils();
      #region Services
      services.AddScoped<IReadService<SiteSettings>, SiteSettingsService>();
      #endregion

      #region Validators
      services.AddScoped<IValidatorMessage<Subscription>, SubscriptionValidator>();
      services.AddScoped<IValidatorMessage<string>, CategoryValidator>();
      #endregion

      services.AddSingleton<IQueryBuilder>(sp =>
      {
        var dict = new Dictionary<QueryType, IQueryBuilder>
        {
          {
            QueryType.Category,
            new CategoryQueryBuilder()
          }
        };

        return new QueryBuilderComposite(dict);
      });
    })
    .Build();

host.Run();