using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.Entities.Interfaces;
using TestMillion.UseCasesPorts.PropertyImagesPorts;


namespace TestMillion.UseCases.GetPropertyImages
{
    public class GetPropertyImagesInteractor : IGetPropertyImagesInputPort
    {
        private readonly IPropertyImageRepository _repository;
        private readonly IGetPropertyImagesOutputPort _outputPort;
        private readonly IMapper _imapper;
        public GetPropertyImagesInteractor(IPropertyImageRepository repository, IGetPropertyImagesOutputPort outputPort, IMapper imapper) =>
            (_repository, _outputPort, _imapper) = (repository, outputPort, imapper);
        public async Task<Task> Handle(int propertyId)
        {
            var propertyImagesDto = _imapper.Map<IEnumerable<PropertyImageDTO>>(await _repository.GetImageProperties(propertyId));
            await _outputPort.Handle(propertyImagesDto);
            return Task.CompletedTask;
        }
    }
}
