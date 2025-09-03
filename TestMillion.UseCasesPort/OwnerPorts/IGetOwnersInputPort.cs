using System.Threading.Tasks;

namespace TestMillion.UseCasesPorts.OwnerDTOsPorts
{
    public interface IGetOwnersInputPort
    {
        Task<Task> Handle();
    }
}
