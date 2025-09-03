using System.Threading.Tasks;
using TestMillion.DTOs;


namespace TestMillion.UseCasesPorts.OwnerPorts
{
    public interface ICreateOwnerInputPort
    {
        Task Handle(CreateOwnerDTO owner);
    }
}
