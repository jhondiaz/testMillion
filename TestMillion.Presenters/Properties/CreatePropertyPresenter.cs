using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.UseCasesPorts.PropertiesPorts;

namespace TestMillion.Presenters.Properties
{
    public class CreatePropertyPresenter : ICreatePropertyOutputPort, IPresenter<PropertyDTO>
    {
        public PropertyDTO Content { get; private set; }

        public Task Handle(PropertyDTO property)
        {
            Content = property;
            return Task.CompletedTask;
        }
    }
}
