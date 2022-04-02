namespace LimpiandoJuntos.Domain.Dtos {

    public record PuntoDeInteresDto(

        int idFolioDenuncia,
        string UrlFoto,
        int Confirmaciones,
        int Negaciones
    );
}