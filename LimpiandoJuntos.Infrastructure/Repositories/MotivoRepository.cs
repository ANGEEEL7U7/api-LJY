using System;
using System.Linq;
using System.Collections.Generic;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Interfaces;
using LimpiandoJuntos.Infrastructure.Data;
using System.Linq.Expressions;

namespace LimpiandoJuntos.Infrastructure.Repositories
{
    public class MotivoRepository : IMotivoRepository
    {
        private readonly LimpiandoJuntosDbContext _context;

        public MotivoRepository(LimpiandoJuntosDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Motivo> TraerTodos()
        {
            return _context.Motivo;
        }

        public bool VerSiExiste(Expression<Func<Motivo, bool>> expression)
        {
            return _context.Motivo.Any(expression);
        }
    }
}