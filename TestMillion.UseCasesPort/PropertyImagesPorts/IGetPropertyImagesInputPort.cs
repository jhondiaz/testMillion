using System.Threading.Tasks;

namespace TestMillion.UseCasesPorts.PropertyImagesPorts
{
    public interface IGetPropertyImagesInputPort
    {
        Task<Task> Handle(int propertyId);
    }
}
