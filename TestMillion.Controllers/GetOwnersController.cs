using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMillion.DTOs;
using TestMillion.Presenters;
using TestMillion.UseCasesPorts.OwnerDTOsPorts;


namespace TestMillion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GetOwnersController
    {
        private readonly IGetOwnersInputPort _inputPort;
        private readonly IGetOwnersOutputPort _outputPort;
        public GetOwnersController(IGetOwnersInputPort inputPort, IGetOwnersOutputPort outputPort) =>
            (_inputPort, _outputPort) = (inputPort, outputPort);
       
        [HttpGet]
        public async Task<IEnumerable<OwnerDTO>> GetOwners()
        {
            await _inputPort.Handle();
            return ((IPresenter<IEnumerable<OwnerDTO>>)_outputPort).Content;
        }
    }

}
