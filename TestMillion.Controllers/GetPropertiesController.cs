using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestMillion.DTOs;
using TestMillion.Presenters;
using TestMillion.UseCasesPorts.PropertiesPorts;

namespace TestMillion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GetPropertiesController
    {
        private readonly IGetPropertiesInputPort _inputPort;
        private readonly IGetPropertiesOutputPort _outputPort;
        public GetPropertiesController(IGetPropertiesInputPort inputPort, IGetPropertiesOutputPort outputPort) =>
            (_inputPort, _outputPort) = (inputPort, outputPort);
        [HttpGet]
        public async Task<IEnumerable<PropertyDTO>> GetProperties()
        {
            await _inputPort.Handle();
            return ((IPresenter<IEnumerable<PropertyDTO>>)_outputPort).Content;
        }
    }

}
