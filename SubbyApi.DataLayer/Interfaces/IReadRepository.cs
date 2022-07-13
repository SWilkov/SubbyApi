namespace SubbyApi.DataLayer.Interfaces
{
  public interface IReadRepository<T> where T : class
  {
    T Get(int id);
  }
}
