using System.Collections.Generic;
using System.Linq;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Interfaces;

namespace LimpiandoJuntos.Application.Services
{
    public class PuntoDeInteresService : IPuntoDeInteresService
    {
        private readonly IPuntoDeInteresRepository _puntoDeInteresRepository;

        public PuntoDeInteresService(IPuntoDeInteresRepository puntoDeInteresRepository)
        {
            _puntoDeInteresRepository = puntoDeInteresRepository;
        }

        public bool Confirmar(int folio)
        {
            var confirmacion = _puntoDeInteresRepository.TraerPorFolio(folio);
            confirmacion.Confirmaciones++;
            return _puntoDeInteresRepository.Actualizar(confirmacion);
        }

        public bool Negar(int folio)
        {
            var puntoDeInteres = _puntoDeInteresRepository.TraerPorFolio(folio);
            puntoDeInteres.Negaciones++;
            return _puntoDeInteresRepository.Actualizar(puntoDeInteres);
        }

        public IEnumerable<PuntoDeInteresDto> TraerPuntos()
        {
            return _puntoDeInteresRepository.TraerPuntos()
                .Select(p => new PuntoDeInteresDto(
                    idFolioDenuncia: p.DenunciaId,
                    UrlFoto: p.UrlFoto,
                    Confirmaciones: p.Confirmaciones,
                    Negaciones: p.Negaciones));
        }
    }
}