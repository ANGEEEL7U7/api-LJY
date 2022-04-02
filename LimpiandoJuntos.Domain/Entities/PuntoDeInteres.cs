#nullable disable

namespace LimpiandoJuntos.Domain.Entities
{
    public partial class PuntoDeInteres
    {
        public int DenunciaId { get; set; }
        public string UrlFoto { get; set; }
        public int Confirmaciones { get; set; }
        public int Negaciones { get; set; }

        public virtual Denuncia Denuncia { get; set; }
    }
}