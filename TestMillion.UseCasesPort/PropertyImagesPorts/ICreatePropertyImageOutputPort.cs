using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertyImagesPorts
{
    public interface ICreatePropertyImageOutputPort
    {
        Task Handle(PropertyImageDTO propertyImage);
    }
}
