using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Dtos.Responses;
using LimpiandoJuntos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LimpiandoJuntos.Api.Controllers
{
    //Nota se decora con una propiedad que se llama [ApiController]
    //que nos indica que carece de una interfaz grafica 
    [ApiController]
    [Route("api/Denuncia")]
    //Estamos hererdando de controllerBase
    //todos los controladores deben heredar de él
    public class DenunciaController : ControllerBase
    {
        private readonly IDenunciaService _denunciaService;
        private readonly IValidator<DenunciaRequest> _createValidator;

        public DenunciaController(IDenunciaService denunciaService, IValidator<DenunciaRequest> createValidator)
        {
            _denunciaService = denunciaService;
            _createValidator = createValidator;
        }

        [HttpGet]
        public IEnumerable<DenunciaResponse> TraerTodasLasDenuncias()
        {
            return _denunciaService.TraerTodasLasDenuncias();
        }
        [HttpGet]
        [Route("{folio:int}")]
        public ActionResult<DenunciaResponse> TraerDenunciaPorFolio(int folio)
        {
            var denuncia = _denunciaService.TraerDenunciaPorFolio(folio);
            if (denuncia == null)
                return NotFound($"No se encontró la denuncia con el folio {folio}");
            return Ok(denuncia);
        }
        
        [HttpPost]
        public ActionResult CrearDenuncia(DenunciaRequest denuncia)
        {
            var validationResult = _createValidator.Validate(denuncia);

            if (!validationResult.IsValid)
                return UnprocessableEntity(
                    validationResult.Errors
                        .Select(x => $"{x.PropertyName} - Error: {x.ErrorMessage}"));

            try
            {
                return Ok(_denunciaService.CrearDenuncia(denuncia));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}