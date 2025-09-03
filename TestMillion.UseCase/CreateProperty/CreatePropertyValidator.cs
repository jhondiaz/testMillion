using FluentValidation;
using TestMillion.DTOs;

namespace TestMillion.UseCases.CreateProperty
{
    public class CreatePropertyValidator : AbstractValidator<CreatePropertyDTO>
    {
        public CreatePropertyValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("La Dirección es requerida");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El Nombre es requerido");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("El Precio es requerido");
            RuleFor(x => x.CodeInternal).NotEmpty().WithMessage("El Código interno es requerido");
            RuleFor(x => x.Year).GreaterThan(0).WithMessage("El Año es requerido");
        }
    }
}
