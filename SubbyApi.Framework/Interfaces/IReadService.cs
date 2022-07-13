namespace SubbyApi.Framework.Interfaces
{
  public interface IReadService<T> where T : class
  {
    T Get(int id);  
  }
}
