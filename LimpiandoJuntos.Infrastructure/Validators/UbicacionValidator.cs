using FluentValidation;
using LimpiandoJuntos.Domain.Entities;

namespace LimpiandoJuntos.Infrastructure.Validators
{
    public class UbicacionValidator : AbstractValidator<Ubicacion>
    {
        public UbicacionValidator()
        {
            RuleFor(u => u.Estado.ToLower().Replace("á", "a")).Equal("yucatan")
                .WithMessage("La ubicación debe pertenecer al estado de Yucatán.");
            RuleFor(u => u.Municipio).NotEmpty().NotNull()
                .WithMessage("No se encontró el municipio.");
        }
    }
}