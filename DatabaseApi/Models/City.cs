using System;
using System.Collections.Generic;

namespace DatabaseApi.Models
{
    public partial class City
    {
        public decimal? Cityid { get; set; }
        public string Zipcode { get; set; }
        public string City1 { get; set; }
        public string State { get; set; }
        public string Areacode { get; set; }
        public decimal? Population1990 { get; set; }
        public decimal? Population1980 { get; set; }
        public string Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Populationcdf { get; set; }
    }
}
