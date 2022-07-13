using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SubbyApi.Framework.Interfaces;
using SubbyApi.Framework.Models;

namespace SubbyApi.Functions
{
  public class GetSiteSettings
  {
    private readonly ILogger _logger;
    private readonly IReadService<SiteSettings> _settingsService;

    public GetSiteSettings(ILoggerFactory loggerFactory, IReadService<SiteSettings> settingsService)
    {
      _logger = loggerFactory.CreateLogger<GetSiteSettings>();
      _settingsService = settingsService;
    }

    [Function("site-settings")]
    public async Task<HttpResponseData> Get([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
      _logger.LogInformation("C# HTTP trigger function processed a request.");

      var settings = _settingsService.Get(1);
      if (settings == null)
      {
        var nf = req.CreateResponse(HttpStatusCode.NotFound);
        return nf;
      }

      var response = req.CreateResponse(HttpStatusCode.OK);
      await response.WriteAsJsonAsync<SiteSettings>(settings);
      return response;
    }
  }
}
