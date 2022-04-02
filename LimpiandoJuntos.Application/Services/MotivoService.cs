using System.Collections.Generic;
using System.Linq;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Interfaces;

namespace LimpiandoJuntos.Application.Services
{
    public class MotivoService : IMotivoService
    {
        private readonly IMotivoRepository _motivoRepository;

        public MotivoService(IMotivoRepository motivoRepository)
        {
            _motivoRepository = motivoRepository;
        }

        public IEnumerable<MotivoDto> TraerMotivos()
        {
            return _motivoRepository.TraerTodos()
                .Select(m => new MotivoDto(
                    IdMotivo: m.Id,
                    Motivo: m.MotivoDenuncia));
        }
    }
}