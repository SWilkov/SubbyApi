using SubbyApi.Framework.Interfaces;
using SubbyApi.DataLayer.MySQL.EFCore.DataModels;

namespace SubbyApi.DataLayer.MySQL.EFCore.Interfaces
{
  public interface IMapper<T, U> 
    where T: IFrameworkEntity
    where U: BaseDataModel
  {
    T Map(U source);
    U Map(T source);
  }
}
