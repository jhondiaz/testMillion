using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.UseCasesPorts.PropertyImagesPorts;

namespace TestMillion.Presenters.PropertyImages
{
    public class GetPropertyImagesPresenter : IGetPropertyImagesOutputPort, IPresenter<IEnumerable<PropertyImageDTO>>
    {
        public IEnumerable<PropertyImageDTO> Content { get; private set; }

        public Task Handle(IEnumerable<PropertyImageDTO> propertyImages)
        {
            Content = propertyImages;
            return Task.CompletedTask;
        }
    }
}
