using System.Threading.Tasks;
using TestMillion.DTOs;


namespace TestMillion.UseCasesPorts.OwnerPorts
{
    public interface ICreateOwnerOutputPort
    {
        Task Handle(OwnerDTO owner);
    }
}
