using System.Collections.Generic;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LimpiandoJuntos.Api.Controllers
{
    [ApiController]
    [Route("api/Motivo")]
    public class MotivoController : ControllerBase
    {
        private readonly IMotivoService _motivoService;

        public MotivoController(IMotivoService motivoService)
        {
            _motivoService = motivoService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<MotivoDto>> ConsultarMotivos()
        {
            return Ok(_motivoService.TraerMotivos());
        }
        
    }
}