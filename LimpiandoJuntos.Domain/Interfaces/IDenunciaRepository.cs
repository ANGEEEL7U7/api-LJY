using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Dtos;

//PASO 2 Se crea la interfaz, es el esqueleto de la implemenraci[on
namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IDenunciaRepository
    {
        int GuardarDenuncia(Denuncia denuncia);
        IEnumerable<Denuncia> TraerTodasLasDenuncias();
        Denuncia TraerDenunciaPorFolio(int folio);
    }
}