using Microsoft.Extensions.Logging;
using SubbyApi.Utils.Interfaces;
using SubbyApi.Utils.Models;

namespace SubbyApi.Validators
{
  public class CategoryValidator : IValidatorMessage<string>
  {
    private readonly ILogger _logger;
    private readonly IEnvironmentService _environmentService;
    public CategoryValidator(IEnvironmentService environmentService,
      ILogger<CategoryValidator> logger)
    {
      _environmentService = environmentService;
      _logger = logger;
    }

    public ValidationInformation Validate(string item)
    {
      if (string.IsNullOrWhiteSpace(item))
        throw new ArgumentNullException(nameof(item));

      var info = new ValidationInformation { Message = string.Empty, Result = ValidationResult.Valid };

      var categoryList = Environment.GetEnvironmentVariable("Categories");
      if (string.IsNullOrWhiteSpace(categoryList))
      {
        //TODO Log this to App Insights
        var message = "No categories found in config!";
        _logger.LogError(message);
        info.Result = ValidationResult.Invalid;
        info.Message = message;
        return info;
      }

      var categories = categoryList.Split(",");
      if (categories == null || !categories.Any())
      {
        var message = "Error in config zero categories found!";
        _logger.LogError(message);
        info.Result = ValidationResult.Invalid;
        info.Message = message;
        return info;
      }

      var category = categories.FirstOrDefault(x => x.ToLower() == item.ToLower());

      if (category == null)
      {
        var message = $"Could not find ${item} in config.";
        _logger.LogError(message);
        info.Result = ValidationResult.Invalid;
        info.Message = message;
        return info;
      }

      return info;
    }
  }
}
