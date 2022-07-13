using SubbyApi.Utils.Models;

namespace SubbyApi.Utils.Interfaces
{
    public interface IValidator<T> where T: class
    {
        ValidationResult Validate(T item);
    }
}
