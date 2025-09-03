using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.UseCasesPorts.PropertiesPorts;

namespace TestMillion.Presenters.Properties
{
    public class UpdatePropertyPresenter : IUpdatePropertyOutputPort, IPresenter<PropertyDTO>
    {
        public PropertyDTO Content { get; private set; }

        public Task Handle(PropertyDTO property)
        {
            Content = property;
            return Task.CompletedTask;
        }
    }
}
