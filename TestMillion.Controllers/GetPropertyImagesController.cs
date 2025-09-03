using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.Presenters;
using TestMillion.UseCasesPorts.PropertyImagesPorts;

namespace TestMillion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GetPropertyImagesController
    {
        private readonly IGetPropertyImagesInputPort _inputPort;
        private readonly IGetPropertyImagesOutputPort _outputPort;
        public GetPropertyImagesController(IGetPropertyImagesInputPort inputPort, IGetPropertyImagesOutputPort outputPort) =>
            (_inputPort, _outputPort) = (inputPort, outputPort);
        [HttpGet("{id}")]
        public async Task<IEnumerable<PropertyImageDTO>> GetProperties(int id)
        {
            await _inputPort.Handle(propertyId: id);
            return ((IPresenter<IEnumerable<PropertyImageDTO>>)_outputPort).Content;
        }
    }

}
