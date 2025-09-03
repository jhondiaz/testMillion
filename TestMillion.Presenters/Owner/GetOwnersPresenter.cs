using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.UseCasesPorts.OwnerDTOsPorts;


namespace TestMillion.Presenters.Properties
{
    public class GetOwnersPresenter : IGetOwnersOutputPort, IPresenter<IEnumerable<OwnerDTO>>
    {
        public IEnumerable<OwnerDTO> Content { get; private set; }

        public Task Handle(IEnumerable<OwnerDTO> owner)
        {
            Content = owner;
            return Task.CompletedTask;
        }
    }
}
