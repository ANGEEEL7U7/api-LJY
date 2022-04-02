using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using LimpiandoJuntos.Domain.Entities;

namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IMotivoRepository
    {
        IEnumerable<Motivo> TraerTodos();
        bool VerSiExiste(Expression<Func<Motivo, bool>> expression);
    }
}