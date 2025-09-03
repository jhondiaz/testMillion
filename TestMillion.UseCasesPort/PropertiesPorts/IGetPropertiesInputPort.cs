using System.Threading.Tasks;

namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface IGetPropertiesInputPort
    {
        Task<Task> Handle();
    }
}
