namespace LimpiandoJuntos.Domain.Dtos.Responses
{
    public record UbicacionResponse
    (
        int DenunciaId,
        string Direccion,
        string Colonia,
        string CodigoPostal,
        string Municipio,
        string Estado,
        string Latlng
    );
}