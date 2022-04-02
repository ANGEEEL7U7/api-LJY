using System.Collections.Generic;

using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Entities;

namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IPuntoDeInteresService
    {
        IEnumerable<PuntoDeInteresDto> TraerPuntos();
        bool Confirmar(int folio);
        bool Negar(int folio);

    }
}