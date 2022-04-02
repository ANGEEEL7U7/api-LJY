using System;

namespace LimpiandoJuntos.Domain.Dtos.Responses
{
    public record DenunciaResponse(
        int Id,
        DateTime Fecha,
        string Notas,
        MotivoDto Motivo,
        PuntoDeInteresDto PuntoDeInteresDto,
        UbicacionResponse UbicacionResponse
    );
}