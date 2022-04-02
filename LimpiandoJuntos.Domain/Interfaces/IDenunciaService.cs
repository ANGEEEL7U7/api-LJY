using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Dtos.Responses;

// PASO 3
namespace LimpiandoJuntos.Domain.Interfaces
{
    public interface IDenunciaService
    {
        int CrearDenuncia(DenunciaRequest denuncia);
        
        IEnumerable<DenunciaResponse> TraerTodasLasDenuncias();

        DenunciaResponse TraerDenunciaPorFolio(int folio);
    }
}  