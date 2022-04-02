using LimpiandoJuntos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LimpiandoJuntos.Api.Controllers
{

    [ApiController]
    [Route("api/PuntoDeInteres")]
    public class PuntoDeInteresController : ControllerBase
    {
        private readonly IPuntoDeInteresService _puntoDeInteresService;

        public PuntoDeInteresController(IPuntoDeInteresService puntoDeInteresService) {
            _puntoDeInteresService = puntoDeInteresService;
        }
        
        [HttpPut]
        [Route("{folio:int}/Negacion")]
        public IActionResult Negar(int folio){
            var seNego = _puntoDeInteresService.Negar(folio);
            if (seNego)
                return NoContent();
            return Conflict("No se pudo negar el punto de interés.");
        }
        
        [HttpPut]
        [Route("{folio:int}/Confirmacion")]
        public IActionResult Confirmacion(int folio) {
            var seConfirmo = _puntoDeInteresService.Confirmar(folio);
            if (seConfirmo)
                return NoContent();
            return Conflict("No se pudo confirmar el punto de interés.");
        }
    }
}