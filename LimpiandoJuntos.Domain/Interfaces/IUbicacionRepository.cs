using LimpiandoJuntos.Domain.Entities;

namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IUbicacionRepository
    {
        Ubicacion ObtenerUbicacion(string latLng);
    }
}