using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface IUpdatePropertyOutputPort
    {
        Task Handle(PropertyDTO property);
    }
}
