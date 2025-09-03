using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.Presenters;
using TestMillion.UseCasesPorts.OwnerPorts;

namespace TestMillion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreateOwnerController
    {
        private readonly ICreateOwnerInputPort _inputPort;
        private readonly ICreateOwnerOutputPort _outputPort;
        public CreateOwnerController(ICreateOwnerInputPort inputPort, ICreateOwnerOutputPort outputPort) =>
            (_inputPort, _outputPort) = (inputPort, outputPort);
        [HttpPost]
        public async Task<OwnerDTO> CreateOwner(CreateOwnerDTO owner)
        {
            await _inputPort.Handle(owner);
            return ((IPresenter<OwnerDTO>)_outputPort).Content;
        }
    }

}
