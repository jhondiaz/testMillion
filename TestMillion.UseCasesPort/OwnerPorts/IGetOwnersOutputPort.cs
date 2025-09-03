using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.OwnerDTOsPorts
{
    public interface IGetOwnersOutputPort
    {
        Task Handle(IEnumerable<OwnerDTO> owners);
    }
}
