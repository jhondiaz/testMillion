using FluentValidation;
using TestMillion.DTOs;
using TestMillion.Entities.Interfaces;


namespace TestMillion.UseCases.UpdateProperty
{
    public class UpdatePropertyValidator : AbstractValidator<UpdatePropertyDTO>
    {
        private readonly IPropertyRepository _repository;
        private readonly IOwnerRepository _ownerRepository;
        public UpdatePropertyValidator(IPropertyRepository repository, IOwnerRepository ownerRepository)
        {
            _repository = repository;
            _ownerRepository = ownerRepository;
            RuleFor(x => x.Id).Must(IsPropertyExist).WithMessage("Debe proporcionar una propiedad existente");
            RuleFor(x => x.OwnerId).Must(IsOwnerExist).WithMessage("Debe propercionar un id de un Dueño existente");
            RuleFor(x => x.Address).NotEmpty().WithMessage("La Dirección es requerida");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El Nombre es requerido");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("El Precio es requerido");
            RuleFor(x => x.CodeInternal).NotEmpty().WithMessage("El Código interno es requerido");
            RuleFor(x => x.Year).GreaterThan(0).WithMessage("El Año es requerido");
        }
        private bool IsPropertyExist(int PropertyId)
        {
            var property = _repository.GetPropertyAsync(PropertyId).GetAwaiter().GetResult();
            if (property == null) return false;
            return true;
        }
        private bool IsOwnerExist(int? OwnerId)
        {
            if (OwnerId.HasValue)
            {
                var property = _ownerRepository.GetOwner(OwnerId.Value).GetAwaiter().GetResult();
                if (property == null) return false;
                return true;
            }
            return true;
        }
    }

}
