using System;
using System.Collections.Generic;
using System.Text;

namespace SubbyApi.DataLayer.Cosmos.DataModels
{
  public class SubscriptionOffer
  {    
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Description { get; set; }
  }
}
