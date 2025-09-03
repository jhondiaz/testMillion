using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface IGetPropertiesOutputPort
    {
        Task Handle(IEnumerable<PropertyDTO> properties);
    }
}
