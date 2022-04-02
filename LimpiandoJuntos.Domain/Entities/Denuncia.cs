using System;

#nullable disable

namespace LimpiandoJuntos.Domain.Entities
{
    public partial class Denuncia
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Notas { get; set; }
        public int MotivoId { get; set; }

        public virtual Motivo Motivo { get; set; }
        public virtual PuntoDeInteres PuntoDeInteres { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
    }
}