using SubbyApi.Utils.Interfaces;

namespace SubbyApi.Utils.Services
{
  public class EnvironmentService : IEnvironmentService
    {
        public string Get(string key) => Environment.GetEnvironmentVariable(key) ?? String.Empty;
    }
}
