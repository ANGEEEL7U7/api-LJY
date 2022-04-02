using System.Collections.Generic;

#nullable disable

namespace LimpiandoJuntos.Domain.Entities
{
    public partial class Motivo
    {
        public Motivo()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int Id { get; set; }
        public string MotivoDenuncia { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}