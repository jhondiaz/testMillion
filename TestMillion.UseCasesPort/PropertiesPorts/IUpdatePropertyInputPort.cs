using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface IUpdatePropertyInputPort
    {
        Task Handle(UpdatePropertyDTO property);
    }


  
}
