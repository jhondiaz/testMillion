using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.Entities.Interfaces;
using TestMillion.UseCasesPorts.OwnerDTOsPorts;
using TestMillion.UseCasesPorts.PropertiesPorts;


namespace TestMillion.UseCases.GetProperties
{
    public class GetPropertiesInteractor : IGetPropertiesInputPort
    {
        private readonly IPropertyRepository _repository;
        private readonly IGetPropertiesOutputPort _outputPort;
        private readonly IMapper _imapper;
        public GetPropertiesInteractor(IPropertyRepository repository, IGetPropertiesOutputPort outputPort, IMapper imapper) =>
            (_repository, _outputPort, _imapper) = (repository, outputPort, imapper);
        public async Task<Task> Handle()
        {
            var propertiesDto = _imapper.Map<IEnumerable<PropertyDTO>>(await _repository.GetPropertiesAsync());
            await _outputPort.Handle(propertiesDto);
            return Task.CompletedTask;
        }
    }

}
