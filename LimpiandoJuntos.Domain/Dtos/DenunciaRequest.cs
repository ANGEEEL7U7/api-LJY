namespace LimpiandoJuntos.Domain.Dtos
{
    public record DenunciaRequest(
        int IdMotivo,
        string Geoubicacion,
        string UrlFoto,
        string Notas
    );
}