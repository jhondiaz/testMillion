using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.Presenters;
using TestMillion.UseCasesPorts.PropertyImagesPorts;

namespace TestMillion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CreatePropertyImagesController
    {
        private readonly ICreatePropertyImageInputPort _inputPort;
        private readonly ICreatePropertyImageOutputPort _outputPort;
        public CreatePropertyImagesController(ICreatePropertyImageInputPort inputPort, ICreatePropertyImageOutputPort outputPort) =>
            (_inputPort, _outputPort) = (inputPort, outputPort);

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<PropertyImageDTO> CreatePropertyImage([FromForm] UploadImageRequest request)
        {


            using var memoryStream = new MemoryStream();
            await request.File.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();
            string base64Image = Convert.ToBase64String(bytes);

            var property = new CreatePropertyImageDTO
            {
                Enabled = request.Enabled,
                PropertyId = request.PropertyId,
                File = base64Image
            };

            await _inputPort.Handle(property);
            return ((IPresenter<PropertyImageDTO>)_outputPort).Content;
        }
    }


    public class UploadImageRequest
    {

        public bool Enabled { get; set; }
        public int PropertyId { get; set; }
        public IFormFile File { get; set; }
    }

}
