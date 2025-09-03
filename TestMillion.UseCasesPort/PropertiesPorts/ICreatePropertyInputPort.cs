using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DTOs;


namespace TestMillion.UseCasesPorts.PropertiesPorts
{
    public interface ICreatePropertyInputPort
    {
        Task Handle(CreatePropertyDTO property);
    }
}
