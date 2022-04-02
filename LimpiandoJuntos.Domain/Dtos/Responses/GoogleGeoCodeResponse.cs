using System.Collections.Generic;

namespace LimpiandoJuntos.Domain.Dtos.Responses
{
    public class GoogleGeoCodeResponse
    {
        public string status { get; set; }
        public List<results> results { get; set; }
    }

    public class results
    {
        public List<address_component> address_components { get; set; }
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public List<string> types { get; set; }
    }

    public class geometry
    {
        public location location { get; set; }
        public string location_type { get; set; }
    }

    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
}