
using System.ComponentModel.DataAnnotations;


namespace DatabaseApi.Dtos
{
    public class CityToCreate
    {
        [Required]
        public int Cityid { get; set; }
        public string Zipcode { get; set; }
        public string City1 { get; set; }
        public string State { get; set; }
        public string Areacode { get; set; }
        public int? Population1990 { get; set; }
        public int? Population1980 { get; set; }
        public string Country { get; set; }
        public int? Latitude { get; set; }
        public int? Longitude { get; set; }
        public int? Populationcdf { get; set; }
    }
}
