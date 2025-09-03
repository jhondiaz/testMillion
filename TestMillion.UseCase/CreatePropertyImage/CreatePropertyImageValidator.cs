using FluentValidation;
using TestMillion.DTOs;
using TestMillion.Entities.Interfaces;

namespace TestMillion.UseCases.CreatePropertyImage
{
    public class CreatePropertyImageValidator : AbstractValidator<CreatePropertyImageDTO>
    {
        private readonly IPropertyRepository _repository;
        public CreatePropertyImageValidator(IPropertyRepository repository)
        {
            _repository = repository;
            RuleFor(x => x.PropertyId).Must(IsPropertyExist).WithMessage("Debe proporcionar una propiedad existente");
            RuleFor(x => x.File).NotEmpty();
        }
        private bool IsPropertyExist(int PropertyId)
        {
            var property = _repository.GetPropertyAsync(PropertyId).GetAwaiter().GetResult();
            if (property == null) return false;
            return true;
        }
    }
}
