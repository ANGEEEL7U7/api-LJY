using System;
using FluentValidation;
using LimpiandoJuntos.Domain.Dtos; 
using LimpiandoJuntos.Domain.Interfaces;

namespace LimpiandoJuntos.Infrastructure
{
    public class DenunciaRequestValidator : AbstractValidator<DenunciaRequest>
    {
        private readonly IMotivoRepository _motivorepository;
        private readonly IPuntoDeInteresRepository _puntointeresrepository;
        public DenunciaRequestValidator(IMotivoRepository motivorepository, IPuntoDeInteresRepository puntointeresrepository)
        {
            _motivorepository = motivorepository;
            _puntointeresrepository = puntointeresrepository;

            RuleFor(dn => dn.IdMotivo).NotNull().NotEmpty().WithMessage("Este campo no puede estar vacío.");
            RuleFor(dn => dn.Geoubicacion).NotNull().NotEmpty().WithMessage("No ha puesto la geoubicación del lugar");
            RuleFor(dn => dn.UrlFoto).NotNull().NotEmpty().WithMessage("No ha puesto la URL de la foto del lugar.");
            RuleFor(dn => dn.IdMotivo).Must(ExisteMotivo).WithMessage("No existe ese id para motivo.");
            RuleFor(dn => dn.UrlFoto).Must(NoExisteUrlFoto).WithMessage("Esta url ya a sido agregada. Intente con otra...");
        }

        public bool ExisteMotivo(int motivoId)
        {
            return _motivorepository.VerSiExiste(m => m.Id == motivoId);
        }

        public bool NoExisteUrlFoto(string url)
        {
            return !_puntointeresrepository.VerSiExiste(p => p.UrlFoto == url);
        }
    }
}