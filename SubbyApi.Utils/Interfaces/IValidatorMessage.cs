using SubbyApi.Utils.Models;

namespace SubbyApi.Utils.Interfaces
{
    public interface IValidatorMessage<T> where T: class
    {
        ValidationInformation Validate(T item);
    }
}
