using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LimpiandoJuntos.Domain.Entities;

namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IPuntoDeInteresRepository
    {
        IEnumerable<PuntoDeInteres> TraerPuntos();
        PuntoDeInteres TraerPorFolio(int folio);
        bool Actualizar(PuntoDeInteres puntoDeInteres);
        bool VerSiExiste(Expression<Func<PuntoDeInteres, bool>> expression);

    }
}