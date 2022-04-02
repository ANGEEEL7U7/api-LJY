using System.Collections.Generic;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Entities;

namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IMotivoService
    {
        IEnumerable<MotivoDto> TraerMotivos();
    }
}
