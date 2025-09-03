using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.Entities.Interfaces;
using TestMillion.UseCasesPorts.OwnerDTOsPorts;


namespace TestMillion.UseCases.GetOwners
{
    public class GetOwnersInteractor : IGetOwnersInputPort
    {
        private readonly IOwnerRepository _repository;
        private readonly IGetOwnersOutputPort _outputPort;
        private readonly IMapper _imapper;
        public GetOwnersInteractor(IOwnerRepository repository, IGetOwnersOutputPort outputPort, IMapper imapper) =>
            (_repository, _outputPort, _imapper) = (repository, outputPort, imapper);
            public async Task<Task> Handle()
            {
            var ownerDto = _imapper.Map<IEnumerable<OwnerDTO>>(await _repository.GetOwnersAsync());
            await _outputPort.Handle(ownerDto);
            return Task.CompletedTask;
        }
    }

}
