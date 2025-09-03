using System.Threading.Tasks;

namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface IGetPropertyInputPort
    {
        Task<Task> Handle(int id);
    }
}
