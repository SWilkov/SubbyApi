using SubbyApi.Framework.Interfaces;
using SubbyApi.Framework.Models;
using SubbyApi.DataLayer.Interfaces;

namespace SubbyApi.Services
{
  public  class SiteSettingsService : IReadService<SiteSettings>
  {
    private readonly IReadRepository<SiteSettings> _repository;

    public SiteSettingsService(IReadRepository<SiteSettings> repository)
    {
      _repository = repository;
    }

    public SiteSettings Get(int id)
    {
      if (id == default(int))
        throw new ArgumentNullException("id");

      return _repository.Get(id);
    }
  }
}
