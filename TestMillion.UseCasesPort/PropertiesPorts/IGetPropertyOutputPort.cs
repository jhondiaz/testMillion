using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface IGetPropertyOutputPort
    {
        Task Handle(PropertyDTO property);
    }
}
