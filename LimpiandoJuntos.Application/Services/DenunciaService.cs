using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimpiandoJuntos.Domain.Dtos;
using LimpiandoJuntos.Domain.Dtos.Responses;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Interfaces;

namespace LimpiandoJuntos.Application.Services
{
    public class DenunciaService : IDenunciaService
    {
        private readonly IDenunciaRepository _denunciaRepository;
        private readonly IUbicacionService _ubicacionService;

        public DenunciaService(IDenunciaRepository denunciaRepository, IUbicacionService ubicacionService)
        {
            _denunciaRepository = denunciaRepository;
            _ubicacionService = ubicacionService;
        }

        public int CrearDenuncia(DenunciaRequest denuncia)
        {
            var dn = new Denuncia
            {
                Fecha = DateTime.Now,
                Notas = denuncia.Notas,
                MotivoId = denuncia.IdMotivo,
                Ubicacion = _ubicacionService.ObtenerUbicacion(denuncia.Geoubicacion),
                PuntoDeInteres = new PuntoDeInteres
                {
                    UrlFoto = denuncia.UrlFoto
                }
            };

            return _denunciaRepository.GuardarDenuncia(dn);
        }

        public IEnumerable<DenunciaResponse> TraerTodasLasDenuncias()
        {
            return _denunciaRepository.TraerTodasLasDenuncias()
                .Select(ConvertirADenunciaResponse);
        }



        public DenunciaResponse TraerDenunciaPorFolio(int folio)
        {
            var denuncia = _denunciaRepository.TraerDenunciaPorFolio(folio);
            return denuncia is null ? null : ConvertirADenunciaResponse(denuncia);
        }
        
        private static DenunciaResponse ConvertirADenunciaResponse(Denuncia denuncia)
        {
            return new DenunciaResponse(
                denuncia.Id,
                denuncia.Fecha,
                denuncia.Notas,
                new MotivoDto
                (
                    denuncia.MotivoId,
                    denuncia.Motivo.MotivoDenuncia
                ),
                new PuntoDeInteresDto(
                    denuncia.Id,
                    denuncia.PuntoDeInteres.UrlFoto,
                    denuncia.PuntoDeInteres.Confirmaciones,
                    denuncia.PuntoDeInteres.Negaciones
                ),
                new UbicacionResponse(
                    denuncia.Ubicacion.DenunciaId,
                    denuncia.Ubicacion.Direccion ?? "-",
                    denuncia.Ubicacion.Colonia ?? "-",
                    denuncia.Ubicacion.CodigoPostal ?? "-",
                    denuncia.Ubicacion.Municipio,
                    denuncia.Ubicacion.Estado,
                    denuncia.Ubicacion.LatLng
                )
            );
        }
    }
}