using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.UseCasesPorts.OwnerDTOsPorts;
using TestMillion.UseCasesPorts.PropertiesPorts;

namespace TestMillion.Presenters.Properties
{
    public class GetPropertiesPresenter : IGetPropertiesOutputPort, IPresenter<IEnumerable<PropertyDTO>>
    {
        public IEnumerable<PropertyDTO> Content { get; private set; }

        public Task Handle(IEnumerable<PropertyDTO> properties)
        {
            Content = properties;
            return Task.CompletedTask;
        }
    }
}
