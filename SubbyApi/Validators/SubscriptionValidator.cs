using SubbyApi.Utils.Interfaces;
using SubbyApi.Utils.Models;
using SubbyApi.DataLayer.Cosmos.DataModels;
using System;

namespace SubbyApi.Validators
{
    public class SubscriptionValidator : IValidatorMessage<Subscription>
  {
    public ValidationInformation Validate(Subscription item)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      var info = new ValidationInformation
      {
        Message = string.Empty,
        Result = ValidationResult.Valid
      };
      
      if (string.IsNullOrWhiteSpace(item.Product) && string.IsNullOrWhiteSpace(item.Name))
      {
        info.Message += "Subscription is missing a PRODUCT. ";
        info.Result = ValidationResult.Invalid;
      }

      if (item.Company == null || string.IsNullOrWhiteSpace(item.Company.Name))
      {
        info.Message = "Subscription is missing a COMPANY ";
        info.Result = ValidationResult.Invalid;
      }

      return info;
    }
  }
}
