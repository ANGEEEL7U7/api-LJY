using LimpiandoJuntos.Domain.Dtos.Responses;
using LimpiandoJuntos.Domain.Entities;
using LimpiandoJuntos.Domain.Interfaces;
using RestSharp;

namespace LimpiandoJuntos.Infrastructure.Repositories
{
    public class UbicacionRepository : IUbicacionRepository
    {
        public Ubicacion ObtenerUbicacion(string latLng)
        {
            var ubicacion = new Ubicacion();
            ubicacion.LatLng = latLng;
            string neighborhood = null;
            string sublocality = null;
            string nombreCalle = null;
            string numCalle = null;
            var primerElemento = ObtenerGeocodeDeApi(latLng).results[0];
            foreach (var parteDireccion in primerElemento.address_components)
            {
                //Para encontrar la dirección calle y número
                if (parteDireccion.types.Contains("route"))
                    nombreCalle = parteDireccion.long_name;

                if (parteDireccion.types.Contains("street_number"))
                    numCalle = parteDireccion.long_name;

                // Para encontrar el código postal
                if (parteDireccion.types.Contains("postal_code"))
                    ubicacion.CodigoPostal = parteDireccion.long_name;

                // Para encontrar el municipio
                if (parteDireccion.types.Contains("locality"))
                    ubicacion.Municipio = parteDireccion.long_name;

                // Para encontrar el estado
                if (parteDireccion.types.Contains("administrative_area_level_1"))
                    ubicacion.Estado = parteDireccion.long_name;

                // Para encontrar la colonia
                if (parteDireccion.types.Contains("neighborhood"))
                    neighborhood = parteDireccion.long_name;

                if (parteDireccion.types.Contains("sublocality"))
                    sublocality = parteDireccion.long_name;
            }

            if (nombreCalle != null && numCalle != null)
                ubicacion.Direccion = nombreCalle + " " + numCalle;
            else
                ubicacion.Direccion = nombreCalle ?? numCalle;

            // se usa el null coalesing operator
            // Devuelve el primer valor no nulo
            ubicacion.Colonia = neighborhood ?? sublocality;
            return ubicacion;
        }

        private GoogleGeoCodeResponse ObtenerGeocodeDeApi(string latLng)
        {
            var url = "https://maps.googleapis.com/maps/api/geocode/json";
            var client = new RestClient(url);

            var request = new RestRequest();
            request.AddQueryParameter("key", "AIzaSyCdhud8Jv2oD2mv2hHM8nRJ7srZJFBJAAA");
            request.AddQueryParameter("latlng", latLng);

            return client.Get<GoogleGeoCodeResponse>(request).Data;
        }
    }
}