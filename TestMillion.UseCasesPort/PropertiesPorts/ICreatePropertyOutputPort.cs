using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface ICreatePropertyOutputPort
    {
        Task Handle(PropertyDTO property);
    }
}
