using System;
using System.Linq;
using FluentValidation;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Interfaces;

namespace LimpiandoJuntos.Application.Services
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IUbicacionRepository _ubicacionRepository;
        private readonly IValidator<Ubicacion> _ubicacionValidator;


        public UbicacionService(IUbicacionRepository ubicacionRepository, IValidator<Ubicacion> ubicacionValidator)
        {
            _ubicacionRepository = ubicacionRepository;
            _ubicacionValidator = ubicacionValidator;
        }

        public Ubicacion ObtenerUbicacion(string latLng)
        {
            var entidadUbicacion = _ubicacionRepository.ObtenerUbicacion(latLng);
            // validar la ubicación 
            var ubicacion = _ubicacionValidator.Validate(entidadUbicacion);
            if (ubicacion.IsValid)
                return entidadUbicacion;

            throw new ArgumentException(
                string.Join("\n",
                    ubicacion.Errors.Select(e => e.ErrorMessage)));
        }
    }
}