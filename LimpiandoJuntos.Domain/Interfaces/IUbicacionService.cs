using LimpiandoJuntos.Domain.Entities;

namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IUbicacionService
    {
        Ubicacion ObtenerUbicacion(string latLng);
    }
}