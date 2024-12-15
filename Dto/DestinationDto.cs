using Dadata.Model;

namespace Dadata_API.Dto
{
    public class DestinationDto
    {
        public string country { get; set; }
        public string city { get; set; }
        public string region_with_type { get; set; }
        public string street { get; set; }
        public string street_with_type { get; set; }
        public string house { get; set; }
        public string flat { get; set; }
        public string geo_lat { get; set; }
        public string geo_lon { get; set; }
        public string fias_id { get; set; }

    }
}
