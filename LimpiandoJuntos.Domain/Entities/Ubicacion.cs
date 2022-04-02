#nullable disable

namespace LimpiandoJuntos.Domain.Entities
{
    public partial class Ubicacion
    {
        public int DenunciaId { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string LatLng { get; set; }

        public virtual Denuncia Denuncia { get; set; }
    }
}