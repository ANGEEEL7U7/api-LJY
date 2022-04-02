using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Interfaces;
using LimpiandoJuntos.Infrastructure.Data;


namespace LimpiandoJuntos.Infrastructure.Repositories
{
    public class PuntodeInteresRepository : IPuntoDeInteresRepository
    {
        private readonly LimpiandoJuntosDbContext _context;

        public PuntodeInteresRepository(LimpiandoJuntosDbContext context)
        {
            _context = context;
        }

        public bool Actualizar(PuntoDeInteres puntoDeInteres)
        {
            _context.Update(puntoDeInteres);
            return _context.SaveChanges() > 0;
        }

        public PuntoDeInteres TraerPorFolio(int folio)
        {
            return _context.PuntoDeInteres.First(x => x.DenunciaId == folio);
        }

        public IEnumerable<PuntoDeInteres> TraerPuntos()
        {
            return _context.PuntoDeInteres;
        }

        public bool VerSiExiste(Expression<Func<PuntoDeInteres, bool>> expression)
        {
            return _context.PuntoDeInteres.Any(expression);
        }
    }
}