using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertyImagesPorts
{
    public interface ICreatePropertyImageInputPort
    {
        Task Handle(CreatePropertyImageDTO propertyImage);
    }
}
