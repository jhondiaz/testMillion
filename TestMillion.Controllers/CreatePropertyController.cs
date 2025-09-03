
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.Presenters;
using TestMillion.UseCasesPorts.PropertiesPorts;

namespace TestMillion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreatePropertyController
    {
        private readonly ICreatePropertyInputPort _inputPort;
        private readonly ICreatePropertyOutputPort _outputPort;
        public CreatePropertyController(ICreatePropertyInputPort inputPort, ICreatePropertyOutputPort outputPort) =>
            (_inputPort, _outputPort) = (inputPort, outputPort);
        [HttpPost]
        public async Task<PropertyDTO> CreateProperty(CreatePropertyDTO property)
        {
            await _inputPort.Handle(property);
            return ((IPresenter<PropertyDTO>)_outputPort).Content;
        }
    }

}
