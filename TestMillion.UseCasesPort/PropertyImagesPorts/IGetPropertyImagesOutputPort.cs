using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.DTOs;

namespace TestMillion.UseCasesPorts.PropertyImagesPorts
{
    public interface IGetPropertyImagesOutputPort
    {
        Task Handle(IEnumerable<PropertyImageDTO> propertyImages);
    }
}
