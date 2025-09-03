using Microsoft.AspNetCore.Mvc;
using TestMillion.DTOs;
using TestMillion.Presenters;
using TestMillion.UseCasesPorts.LogInPorts;
using TestMillion.UseCasesPorts.PropertiesPorts;

namespace TestMillion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController
    {
        private readonly IGetLogInInputPort _inputPort;
        private readonly IGetLogInOutputPort _outputPort;
        public AuthenticationController(IGetLogInInputPort inputPort, IGetLogInOutputPort outputPort) =>
            (_inputPort, _outputPort) = (inputPort, outputPort);
        [HttpPost]
        public async Task<UserDTO> LogIn(LogInDTO logIn)
        {
            await _inputPort.Handle(logIn);
            return ((IPresenter<UserDTO>)_outputPort).Content;
        }
    }

}
